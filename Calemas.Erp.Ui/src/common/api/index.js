import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Cache from '../cache'
import Cookie from '../cookie'
import Global from '../global'
import Auth from '../auth'

Vue.use(VueAxios, axios)

export function Api(resource, endpoint) {

    axios.defaults.headers.common['Authorization'] = "Bearer " + Cookie.get(Global.ACCESS_TOKEN);
    axios.defaults.headers.common['Accept-Language'] = "pt-BR";

    this.Resourse = resource;
    this.EndPoint = endpoint;

    this.defaultFilter = {
        pageSize: 10,
        pageIndex: 0,
        isPaginate: true,
        queryOptimizerBehavior: "",
    };

    this.filters = {};
    this.byCache = false;
    this.hasDefaultFilters = true;
    this.lastAction = "none";
    this.url = "";

    this.get = _get;
    this.getDetails = _getDetails;
    this.getDataListCustom = _getDataListCustom;
    this.getDataCustom = _getDataCustom;
    this.getMethodCustom = _getMethodCustom;

    this.post = _post;
    this.put = _put;

    this.delete = _delete;
    this.dataItem = _dataitem;

    var self = this;


    function _post(data) {

        self.lastAction = "post";
        self.url = makeUri();

        return axios
            .post(self.url, data)
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _put(data) {

        self.lastAction = "put";
        self.url = makeUri();

        return axios
            .put(self.url, data)
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _delete() {

        self.lastAction = "delete";
        self.url = makeDeleteBaseUrl();

        return axios
            .delete(self.url)
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _get() {

        self.lastAction = "get";
        self.url = makeGetBaseUrl();

        if (isOffline())
            return loadFromCache().then(handleSuccess, handleError);

        return axios
            .get(self.url)
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _getMethodCustom(behavior) {

        self.lastAction = "get";
        self.filters.filterBehavior = behavior;
        self.url = makeGetCustomMethodBaseUrl();

        if (isOffline())
            return loadFromCache().then(handleSuccess, handleError);

        return axios
            .get(self.url)
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _getDataListCustom() {
        return _getMethodCustom("GetDataListCustom");
    }

    function _getDetails() {
        return _getMethodCustom("GetDetails");
    }

    function _getDataCustom() {
        return _getMethodCustom("GetDataCustom");
    }

    function _dataitem() {
        return _getMethodCustom("GetDataItem");
    }

    function makeGetBaseUrl() {
        return String.format("{0}/{1}", makeUri(), queryStringFilter());
    }

    function makeGetCustomMethodBaseUrl() {
        return String.format("{0}/more/{1}", makeUri(), queryStringFilter());
    }

    function makeDeleteBaseUrl() {
        return String.format("{0}/?{1}", makeUri(), Object.$httpParamSerializer(self.filters));
    }

    function makeUri() {
        return String.format("{0}/{1}", makeEndPont(), self.Resourse)
    }

    function makeEndPont() {

        if (!self.EndPoint)
            return Global.END_POINT_DEFAULT;

        return self.EndPoint;
    }

    function queryStringFilter() {

        var filters = getFilter();

        if (filters.orderFields !== undefined) {
            filters.isOrderByDynamic = true;
            if (filters.orderByType === undefined)
                filters.orderByType = 1;
        }

        if (filters.id !== undefined)
            return String.format("{0}?{1}", filters.id, Object.$httpParamSerializer(filters));

        return String.format("?{0}", Object.$httpParamSerializer(filters));
    }

    function getFilter() {
        if (self.hasDefaultFilters)
            return Object.assign({}, self.defaultFilter, self.filters)

        return self.filters;
    }

    function handleSuccess(response) { addCache(response.data); }

    function handleError(err) {
        if (err && err.status == 401)
            Auth.login();
    }

    function addCache(data) {

        if (!self.byCache)
            return;

        if (self.url == "")
            return;

        if (self.lastAction == "get") {
            if (data.Data != null || (data.DataList != null && data.DataList.length > 0)) {
                data = JSON.stringify(data);
                Cache.Add(self.url, data)
            }
        }
    }

    function loadFromCache() {

        if (!self.byCache)
            return;

        var data = Cache.Get(self.url);
        data = JSON.parse(data);

        return new Promise(function (resolve, reject) {
            if (data != null)
                resolve(data);
            else
                reject("Nada encontrado")
        })
    }

    function isOffline() {
        if (navigator.network != null) {
            var isOffline = !navigator.onLine;
            return isOffline;
        }
        return false;
    }

    String.format = function () {
        var theString = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
            theString = theString.replace(regEx, arguments[i]);
        }
        return theString;
    }

    Object.$httpParamSerializer = function () {
        var obj = arguments[0];
        return Object.entries(obj).map(([key, val]) => `${key}=${val}`).join('&')
    }

}

