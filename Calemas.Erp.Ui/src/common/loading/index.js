import helperclass from 'helperclass' 

export default {
    show: function () {
        helperclass.remove(document.getElementById("spinner"), "hide");
    },
    hide: function () {
        helperclass.add(document.getElementById("spinner"), "hide");
    },
}