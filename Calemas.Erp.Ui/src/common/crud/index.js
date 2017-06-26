import { Api } from '../api'
import { Delete } from './delete'
import { Edit } from './edit'
import { Create } from './create'
import { Filter } from './filter'

export function Crud(params) {

    this.default = {
        resource: null,
        vm: null,
        edit: {
            form: "form-edit",
            showFieldErrorMessage: true,
            showAlertMessage: true,
            alertMessage: "Parece que você não preencheu todos os campos."
        },
        delete: {
            form: "form-delete",
            showFieldErrorMessage: false,
            showAlertMessage: true,
            alertMessage: "Parece que você não preencheu o campo corretamente."
        },
        create: {
            model: {},
            form: "form-create",
            showFieldErrorMessage: true,
            showAlertMessage: true,
            alertMessage: "Parece que você não preencheu todos os campos."
        },
    };

    this.config = Object.assign({}, this.default, params);

    this.api = new Api(this.config.resource);

    this.filter = new Filter({
        api: this.api,
    })

    this.delete = new Delete({
        vm: this.config.vm,
        api: this.api,
        executeFilterAction: this.filter.executeAction,
        form: this.config.delete.form,
    })

    this.edit = new Edit({
        vm: this.config.vm,
        api: this.api,
        executeFilterAction: this.filter.executeAction,
        form: this.config.edit.form,
    })

    this.create = new Create({
        vm: this.config.vm,
        api: this.api,
        executeFilterAction: this.filter.executeAction,
        form: this.config.create.form,
        model: this.config.create.model,
    })

}
