function classReg(className) {
    return new RegExp("(^|\\s+)" + className + "(\\s+|$)");
}

var hasClass, addClass, removeClass, toggleClass;

hasClass = function (elem, c) {
    return classReg(c).test(elem.className);
};
addClass = function (elem, c) {
    if (!hasClass(elem, c)) {
        elem.className = elem.className + ' ' + c;
    }
};
removeClass = function (elem, c) {
    elem.className = elem.className.replace(classReg(c), ' ');
};

toggleClass = function (elem, c) {
    var fn = hasClass(elem, c) ? removeClass : addClass;
    fn(elem, c);
};

export default {
    has: hasClass,
    add: addClass,
    remove: removeClass,
    toggle: toggleClass
}