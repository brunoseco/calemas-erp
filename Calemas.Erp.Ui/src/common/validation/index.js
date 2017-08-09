
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
            .then(result => {
                if (result)
                    return actionIfValid()
            })
            .catch(() => { })
    }

    function _clearForm() {
        var errors = self.config.vm.formErrors.items;
        if (errors) {
            self.config.vm.formErrors.items = errors.filter(function (e) {
                return e.scope !== self.config.form;
            });
        }
    }

}
