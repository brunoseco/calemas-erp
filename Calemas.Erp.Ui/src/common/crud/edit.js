import { Validation } from '../validation'
import Loading from '../loading'

export function Edit(config) {

    this.config = config;

    this.modalIsOpen = false;
    this.model = config.model;
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

    function _executeModal(id, item) {
        self.loading.show();
        self.validation.clearFormErrors();
        self.config.api.filters = item;
        self.config.api.filters.id = id;
        self.config.api.get().then(data => {
            self.modalIsOpen = true;
            self.model = data.data;
            self.loading.hide();
        });
    }

}
