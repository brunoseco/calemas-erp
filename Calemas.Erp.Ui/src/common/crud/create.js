import { Validation } from '../validation'
import Loading from '../loading'

export function Create(config) {

    this.config = config;

    this.modalIsOpen = false;
    this.model = {};
    this.executeModal = _executeModal;
    this.executeAction = _executeAction;
    this.loading = Loading;

    this.validation = new Validation({
        vm: this.config.vm,
        form: this.config.form
    });

    var self = this;

    function _executeAction() {
        self.validation.verifyFormIsValid(() => {
            self.loading.show();
            self.config.api.post(this.model).then(data => {
                self.modalIsOpen = false;
                self.config.executeFilterAction();
                self.loading.hide();
            })
        });
    }

    function _executeModal(item) {
        self.validation.clearFormErrors();
        self.model = {};
        self.modalIsOpen = true;
    }

}
