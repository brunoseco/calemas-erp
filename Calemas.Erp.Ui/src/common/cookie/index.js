
function _get(key) {
    var _name = key + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(_name) == 0) return c.substring(_name.length, c.length);
    }
    return null;
};

function _add(key, data, seconds) {
    if (seconds) {
        var date = new Date();
        date.setTime(date.getTime() + (seconds * 1000));
        var expires = "; expires=" + date.toGMTString();
    } else var expires = "";
    document.cookie = key + "=" + data + expires + "; path=/";
};

function _update(key, data, seconds) {
    _remove(key);
    _add(key, data, seconds);
};

function _remove(key) {
    _add(key, "", -1);
};

export default {
    get: _get,
    add: _add,
    update: _update,
    remove: _remove,
}