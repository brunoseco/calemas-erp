import { Api } from '../api'
import Vue from 'vue'

function _addOption(el, text, value) {
    var option = document.createElement("option");
    option.text = text;
    option.value = value;
    el.add(option);
}

Vue.directive('select', {
    bind: function (el, binding, vnode) {
        _addOption(el, binding.value.default, undefined);
        var api = new Api(binding.value.dataitem);
        api.dataItem().then(data => {
            if (data.dataList) {
                for (var i = 0; i < data.dataList.length; i++)
                    _addOption(el, data.dataList[i].name, data.dataList[i].id);
            }
        });
    }
})