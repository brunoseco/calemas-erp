export function Notification(_vm) {

    this.vm = _vm;

    this.success = _success;
    this.error = _error;
    this.info = _info;

    var self = this;

    function _success(title, text) {
        _show('success', title, text);
    }

    function _error(title, text) {
        _show('error', title, text);
    }

    function _info(title, text) {
        _show('info', title, text);
    }

    function _show(type, title, text) {
        self.vm.$notify({
            duration: 5000,
            type: type,
            title: title,
            text: text
        });
    }
}