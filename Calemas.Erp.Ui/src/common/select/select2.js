import Vue from 'vue'
import select2 from '../../../static/lib/select2/select2.full.min.js'
import '../../../static/lib/select2/select2.min.css'
import { Api } from '../api'

export default {
    name: 'select-search',
    props: ['dataitem', 'value', 'required'],
    template: '<select class="form-control" :required="required"></select>',
    mounted: function () {
        var vm = this
        $(this.$el)
            .select2({width:100})
            .val(this.value)
            .trigger('change')
            .on('change', function () {
                vm.$emit('input', this.value)
            })

        this.getOptions(this.dataitem);
    },
    data() {
        return {
            options: []
        }
    },
    watch: {
        value: function (value) {
            $(this.$el).val(value)
            $(this.$el).trigger('change')
        },
        options: function (options) {
            $(this.$el).empty().select2({ data: options })
        }
    },
    destroyed: function () {
        $(this.$el).off().select2('destroy')
    },
    methods: {
        getOptions: function (dataitem) {
            this.options = [{ text: "Selecione", id: "undefined" }];
            var api = new Api(dataitem);
            api.dataItem().then(data => {
                if (data.dataList) {
                    for (var i = 0; i < data.dataList.length; i++) {
                        this.options.push({ text: data.dataList[i].name, id: data.dataList[i].id });
                    }
                }
            });
        }
    }
}
