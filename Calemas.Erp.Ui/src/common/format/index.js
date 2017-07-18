import moment from 'moment'

Vue.filter('formatDate', function (value) {
    if (value) {
        return moment(String(value)).format('dd/MM/yyyy hh:mm')
    }
});