export function Form(frm) {

    this.form = frm;
    this.$form = $("#" + this.form);
    this.validator = this.$form.validate({ errorClass: "is-invalid", errorElement: "small" });
    this.valid = _valid;
    this.reset = _reset;

    function _valid() {
        return this.validator.form();
    }

    function _reset() {
        this.validator.reset();
    }

    function _destroy() {
        this.validator.destroy();
    }
    
}

$.extend($.validator.messages, {
    required: "Este campo é obrigatório.",
    remote: "Por favor, corrija este campo.",
    email: "Por favor, forne&ccedil;a um endere&ccedil;o eletr&ocirc;nico v&aacute;lido.",
    url: "Por favor, forne&ccedil;a uma URL v&aacute;lida.",
    date: "Por favor, forne&ccedil;a uma data v&aacute;lida.",
    dateISO: "Por favor, forne&ccedil;a uma data v&aacute;lida (ISO).",
    number: "Por favor, forne&ccedil;a um n&uacute;mero v&aacute;lido.",
    digits: "Por favor, forne&ccedil;a somente d&iacute;gitos.",
    creditcard: "Por favor, forne&ccedil;a um cart&atilde;o de cr&eacute;dito v&aacute;lido.",
    equalTo: "Por favor, forne&ccedil;a o mesmo valor novamente.",
    accept: "Por favor, forne&ccedil;a um valor com uma extens&atilde;o v&aacute;lida.",
    maxlength: $.validator.format("Por favor, forne&ccedil;a n&atilde;o mais que {0} caracteres."),
    minlength: $.validator.format("Por favor, forne&ccedil;a ao menos {0} caracteres."),
    rangelength: $.validator.format("Por favor, forne&ccedil;a um valor entre {0} e {1} caracteres de comprimento."),
    range: $.validator.format("Por favor, forne&ccedil;a um valor entre {0} e {1}."),
    max: $.validator.format("Por favor, forne&ccedil;a um valor menor ou igual a {0}."),
    min: $.validator.format("Por favor, forne&ccedil;a um valor maior ou igual a {0}.")
});