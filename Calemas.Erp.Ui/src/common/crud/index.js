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

    var self = this;

    makeApi();

    function executeFilterAction() {
        executeLoadAction(self.modelFilter);
    }

    function executeLoadAction(filters) {
        self.api.filters = filters;
        self.api.Get().then(data => {
            self.result.total = data.Summary.Total;
            self.result.itens = data.DataList;
        });
    }

    function executeDeleteAction() {
        self.api.filters = self.modelDelete;
        this.api.Delete().then(data => {
            self.deleteModalIsOpen = false;
            self.executeFilterAction();
        });
    }

    function executeDeleteModal(item) {
        self.api.filters = item;
        self.api.GetMethodCustom("GetByModel").then(data => {
            self.deleteModalIsOpen = true;
            self.modelDelete = data.Data;
        });
    }

    function makeApi() {
        self.api = new Api(self.config.resource);
    }

}
