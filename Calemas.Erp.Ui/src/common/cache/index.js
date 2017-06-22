
function _get(key) {
    return window.localStorage.getItem(key);
};

function _add(key, data) {
    window.localStorage.setItem(key, data);
};

function _update(key, data) {
    window.localStorage.setItem(key, data);
};

function _remove(key) {
    window.localStorage.removeItem(key);
};

function _reset() {
    window.localStorage.clear();
};

export default {
    get: _get,
    add: _add,
    update: _update,
    remove: _remove,
    reset: _reset,
}