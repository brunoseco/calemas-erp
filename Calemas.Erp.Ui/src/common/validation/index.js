
export function Validation(config) {

    this.default = {
        vm: null,
        form: ""
    }

    this.config = config;

    this.formIsValid = _formIsValid;
    this.clearForm = _clearForm;

    var self = this;

    function _formIsValid(actionIfValid) {
        self.config.vm.$validator
            .validateAll(self.config.form)
            .then(actionIfValid)
            .catch(() => { })
    }

    function _clearForm() {
        self.config.vm.formErrors.errors = self.config.vm.formErrors.errors
            .filter(function (e) {
                return e.scope !== self.config.form;
            })
    }

}
