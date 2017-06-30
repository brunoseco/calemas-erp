import vSelect from 'vue-strap/src/Select'
import vOption from 'vue-strap/src/Option'
import { Api } from '../api'

export default {
    template: `
            <v-select v-model="internal_model" name="name" @change="selected" search justified>
                <v-option value="">Selecione</v-option>
                <v-option v-for="item in itens" key="item.id" :value="item.id">{{ item.name }}</v-option>
            </v-select>`,
    components: { vSelect, vOption },
    props: {
        value: {
            type: Number,
            required: true,
            default: 0
        },
        dataItem: {
            type: String,
            required: true
        },
        name: {
            type: String,
            required: true
        },
    },
    data: function () {
        return {
            internal_model: 0,
            itens: []
        }
    },
    mounted: function () {
        this.internal_model = this.value;
        this.get();
    },
    methods: {
        selected: function () {
            this.$emit('select', { target: { value: this.internal_model } });
        },
        get: function () {
            var api = new Api(this.dataItem);
            api.dataItem().then(data => { this.itens = data.dataList })
        }
    }
};
