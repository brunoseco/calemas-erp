import { Validation } from '../validation'
import Loading from '../loading'

export function Create(params) {

    this.config = params.config;
    this.api = params.api;
    this.executeFilterAction = params.executeFilterAction;
    this.model = params.config.model;

    this.modalIsOpen = false;
    this.setVm = _setVm;
    this.executeModal = _executeModal;
    this.executeAction = _executeAction;    
    this.loading = Loading;
    this.validation = null;

    var self = this;

    function _executeAction() {
        self.validation.formIsValid(() => {
            self.loading.show();
            self.api.post(this.model).then(data => {
                self.modalIsOpen = false;
                self.executeFilterAction();
                self.loading.hide();
            })
        });
    }

    function _executeModal() {
        if (!self.validation) throw "vm is not set";
        self.validation.clearForm();
        self.model = self.config.model;
        self.modalIsOpen = true;
    }

    function _setVm(vm) {
        self.config.vm = vm;
        self.validation = new Validation({
            vm: self.config.vm,
            form: self.config.form
        });
    }

}
