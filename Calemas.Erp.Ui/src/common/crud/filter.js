
export function Filter(config) {

    this.default = {
        api: null,
    };

    this.result = {
        itens: [],
        total: 0
    };

    this.options = {
        pageSize: 10,
        pageIndex: 1,
        isPaginate: true,
        queryOptimizerBehavior: "",
    }

    this.config = config;

    this.model = {};
    this.executeAction = _executeAction;
    this.executePageChanged = _executePageChanged;
    this.orderBy = _orderBy;

    var self = this;

    function _executeAction() {
        _executeLoad(self.model);
    }

    function _executePageChanged(page) {
        self.model.pageIndex = page;
        _executeLoad(self.model);
    }

    function _orderBy(field) {

        self.model.orderFields = [field];
        var type = 0;

        if (self.model.orderByType == 0) type = 1;

        self.model.orderByType = type;
        self.model.isOrderByDynamic = true;

        _executeLoad(self.model);
    }

    function _executeLoad(filters) {

        self.config.api.filters = Object.assign({}, self.options, filters);

        self.config.api.get().then(data => {
            self.result.total = data.summary.total;
            self.result.itens = data.dataList;
        });
    }

}
