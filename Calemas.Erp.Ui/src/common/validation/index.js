
export function Validation(config) {

    this.default = {
        vm: null,
        form: ""
    }

    this.config = config;

    this.verifyFormIsValid = _verifyFormIsValid;
    this.clearFormErrors = _clearFormErrors;

    var self = this;

    function _verifyFormIsValid(actionIfValid) {
        self.config.vm.$validator.validateAll(self.config.form)
            .then(actionIfValid).catch(() => { })
    }

    function _clearFormErrors() {
        self.config.vm.formErrors.errors = self.config.vm.formErrors.errors
            .filter(function (e) {
                return e.scope !== self.config.form;
            })
    }

}
