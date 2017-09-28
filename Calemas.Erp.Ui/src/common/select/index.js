import Vue from 'vue'

//import select2 from '../../../static/lib/select2/select2.full.min.js'
//import '../../../static/lib/select2/select2.min.css'


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
    },
    inserted: function (elem, binding, vnode) {


        //select.val(vnode.context[binding.expression]).trigger("change")
        //select.on("change", function (evt) {
        //    console.log(evt.target.value)
        //    vnode.context[binding.expression] = evt.target.value
        //})
    },
})