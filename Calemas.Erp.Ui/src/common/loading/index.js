import classie from '../classie'

export default {
    show: function () {
        classie.remove(document.getElementById("spinner"), "hide");
    },
    hide: function () {
        classie.add(document.getElementById("spinner"), "hide");
    },
}