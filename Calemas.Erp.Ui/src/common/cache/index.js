function Cache() {

    return {
        Get: _get,
        Add: _add,
        Update: _update,
        Remove: _remove,
        Reset: _reset,
    }

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

}

export default {
    Cache
}