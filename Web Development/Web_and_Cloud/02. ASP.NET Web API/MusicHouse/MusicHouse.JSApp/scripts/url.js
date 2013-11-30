var getUrl = function (counterPage) {
    var rootUrl = "http://localhost:61428/api/";
    var pageQuery, url, currentPage, counterPage;
    if (arguments[0] != null) {
        currentPage = 5 * counterPage;
        pageQuery = '?$top=' + 5 + '&$skip=' + currentPage;
        //var url = './Proxy/Handler1.ashx?url=' + rootUrl + "Album" + pageQuery;
        url = rootUrl + "Album" + pageQuery;
    }
    else {
        url = rootUrl + "Album/"
    }

    return url;
}