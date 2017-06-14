import { Api } from '../api'

export function Crud(params) {
    
    this.default = {
        resource: null
    };

    this.config = Object.assign({}, this.default, params);

    this.deleteModalIsOpen = false;
    this.createModalIsOpen = false;
    this.editModalIsOpen = false;

    this.result = {
        itens: [],
        total: 0
    };

    this.modelDelete = {};
    this.modelEdit = {};
    this.modelCreate = {};
    this.modelFilter = {};

    this.executeDeleteModal = _executeDeleteModal;
    this.executeDeleteAction = _executeDeleteAction;
    this.executeFilterAction = _executeFilterAction;
    this.executeLoadAction = _executeLoadAction;

    var self = this;

    makeApi();

    function _executeFilterAction() {
        self.executeLoadAction(self.modelFilter);
    }

    function _executeLoadAction(filters) {
        self.api.filters = filters;
        self.api.get().then(data => {
            self.result.total = data.Summary.Total;
            self.result.itens = data.DataList;
        });
    }

    function _executeDeleteAction() {
        self.api.filters = self.modelDelete;
        self.api.delete().then(data => {
            self.deleteModalIsOpen = false;
            self.executeFilterAction();
        });
    }

    function _executeDeleteModal(item) {
        self.api.filters = item;
        self.api.getMethodCustom("GetByModel").then(data => {
            self.deleteModalIsOpen = true;
            self.modelDelete = data.Data;
        });
    }

    function makeApi() {
        self.api = new Api(self.config.resource);
    }

}
