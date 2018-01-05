import Vue from 'vue'

import { Api } from '../api'

function _addOption(el, text, value) {
    var option = document.createElement("option");
    option.text = text;
    option.value = value;
    el.add(option);
}

Vue.directive('select', {
    twoWay: true,
    bind: function (el, binding, vnode) {
        if (binding.value.default)
            _addOption(el, binding.value.default, "");

        var api = new Api(binding.value.dataitem);
        api.dataItem().then(data => {
            if (data.dataList) {
                for (var i = 0; i < data.dataList.length; i++) {
                    _addOption(el, data.dataList[i].name, data.dataList[i].id);
                }
            }
        });
    }
})
