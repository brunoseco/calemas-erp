import pagination from 'vue-pagination-bootstrap'
import loading from '../loading'

import { Api } from '../api'
import { Notification } from '../notification'
import { Form } from '../form'

export default {
    components: { pagination },
    data() {
        return {

            resource: null,

            resources: {
                filter: null
            },

            methodGet: null,

            filterPartialIsOpen: false,

            filterOnEnter: true,
            filter: {
                pageSize: 10,
                pageIndex: 1,
                isPaginate: true,
                queryOptimizerBehavior: "",
            },
            result: {
                total: 0,
                itens: []
            }
        }
    },
    computed: {
        apiFilter: function () {
            let resource = this.resource;
            if (this.resources.filter) resource = this.resources.filter;
            return new Api(resource);
        },
    },
    methods: {

        openFilter: function () {
            this.filterPartialIsOpen = !this.filterPartialIsOpen;
        },

        onBeforeFilter: (model) => { },

        onAfterLoad: (result) => { },

        executeFilter: function (filter) {
            if (filter) this.filter = filter;
            this.onBeforeFilter(this.filter);
            this.executeLoad(this.filter);
        },
        executePageChanged: function (index) {
            this.filter.pageIndex = index;
            this.executeLoad(this.filter);
        },
        executeOrderBy: function (field) {
            let type = 0;
            if (this.filter.orderByType == 0) type = 1;
            this.filter.orderFields = [field];
            this.filter.orderByType = type;
            this.filter.isOrderByDynamic = true;
            this.executeLoad(this.filter);
        },
        executeLoad: function (filter) {
            this.showLoading();
            this.apiFilter.filters = filter;

            var request = this.apiFilter.get;
            if (this.methodGet) request = this.apiFilter.getCustom

            request(this.methodGet).then(data => {
                if (data.summary) this.result.total = data.summary.total;
                this.result.itens = data.dataList;
                this.onAfterLoad(data);
                this.hideLoading();
            }, (err) => {

                if (err && err.data && err.data.result && err.data.result.errors)
                    new Notification(this).error("Erro", err.data.result.errors[0]);

                this.hideLoading();
            });
        },

        showLoading: function () {
            loading.show();
        },
        hideLoading: function () {
            loading.hide();
        },

    },

    mounted() {
        if (this.filterOnEnter)
            this.executeFilter();
    }
}
