import { Api } from '../api'
import { Delete } from './delete'
import { Edit } from './edit'
import { Create } from './create'
import { Filter } from './filter'

export function Crud(params) {
    
    this.default = {
        resource: null
    };

    this.config = Object.assign({}, this.default, params);
    
    this.api = new Api(this.config.resource);

    this.filter = new Filter({
        api: this.api,
    })

    this.delete = new Delete({
        api: this.api,
        executeFilterAction: this.filter.executeAction
    })

    this.edit = new Edit({
        api: this.api,
        executeFilterAction: this.filter.executeAction
    })

    this.create = new Create({
        api: this.api,
        executeFilterAction: this.filter.executeAction
    })

    var self = this;
    
    
    
}
