
export function Edit(config) {

    this.default = {
        api: null,
        executeFilterAction: null
    }

    this.config = config;

    this.modalIsOpen = false;
    this.model = {};
    this.executeModal = _executeModal;
    this.executeAction = _executeAction;

    var self = this;

    function _executeAction() {
        self.config.api.post(this.model).then(data => {
            self.modalIsOpen = false;
            self.config.executeFilterAction();
        });
    }

    function _executeModal(item) {
        self.config.api.filters = item;
        self.config.api.getMethodCustom("GetByModel").then(data => {
            self.modalIsOpen = true;
            self.model = data.Data;
        });
    }

}
