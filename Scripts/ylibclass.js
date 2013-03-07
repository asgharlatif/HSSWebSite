
//load Query string into Query Object Array
//Example : queryObj?id=1

var querystring = location.search.replace('?', '').split('&');
var queryObj = {};

for (var i = 0; i < querystring.length; i++) {
    var name = querystring[i].split('=')[0];
    var value = querystring[i].split('=')[1];
    queryObj[name] = value;
}

