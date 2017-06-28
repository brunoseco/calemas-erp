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
            model: {},
            form: "form-edit",
            showFieldErrorMessage: true,
            showAlertMessage: true,
            alertMessage: "Parece que você não preencheu todos os campos."
        },
        delete: {
            model: {},
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
        api: this.api,
        executeFilterAction: this.filter.executeAction,
        config: Object.assign({}, this.default.delete, this.config.delete),
    })

    this.edit = new Edit({
        api: this.api,
        executeFilterAction: this.filter.executeAction,
        config: Object.assign({}, this.default.edit, this.config.edit),
    })

    this.create = new Create({
        api: this.api,
        executeFilterAction: this.filter.executeAction,
        config: Object.assign({}, this.default.create, this.config.create),
    })

}
