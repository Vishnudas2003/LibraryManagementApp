$(document).ready(function() {
    $('#selectDropdown').select2({
        theme: 'bootstrap-5',
        minimumInputLength: 1,
        maximumResultsForSearch: 10,
        ajax: {
            url: '/Book/GetGenres/',
            dataType: 'json',
            delay: 250,
            data: function(params) {
                return {
                    q: params.term,
                    page: params.page || 1
                };
            },
            processResults: function(data, params) {
                params.page = params.page || 1;
                return {
                    results: data,
                    pagination: {
                        more: (params.page * 10) < data.total_count
                    }
                };
            },
            cache: true
        },
        placeholder: 'Search for a genre',
        escapeMarkup: function(markup) {
            return markup;
        },
        templateResult: formatRepo,
        templateSelection: formatRepoSelection
    });

    function formatRepo(repo) {
        if (repo.loading) {
            return repo.text;
        }
        return "<div>" + repo.text + "</div>";
    }

    function formatRepoSelection(repo) {
        return repo.text || repo.text;
    }
});