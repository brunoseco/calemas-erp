import Loading from '../loading'

export function Details(params) {

    this.config = params.config;
    this.api = params.api;
    this.model = params.config.model;

    this.modalIsOpen = false;
    this.executeModal = _executeModal;
    this.loading = Loading;

    var self = this;

    function _executeModal(id, item) {
        self.loading.show();
        if (item) self.api.filters = item;
        if (id) self.api.filters.id = id;
        self.api.get().then(data => {
            self.modalIsOpen = true;
            self.model = data.data;
            self.loading.hide();
        });
    }

}
