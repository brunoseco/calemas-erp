import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Cache from '../cache'
import Constants from '../global'

Vue.use(VueAxios, axios)

export function Api(o) {

    this.Resourse = o;

    this.defaultFilter = {
        pageSize: 10,
        pageIndex: 0,
        isPaginate: true,
        queryOptimizerBehavior: "",
    };

    this.filters = Object.assign({}, this.defaultFilter, {});
    this.byCache = false;
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
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _put(data) {

        self.lastAction = "put";
        self.url = makeUri();

        return axios
            .put(self.url, data)
            .then(
            res => { handleSuccess(res.data); return res.data; },
            err => { handleError(err); return err; });
    }

    function _delete() {

        self.lastAction = "delete";
        self.url = makeDeleteBaseUrl();

        return axios
            .delete(self.url)
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _get() {

        self.lastAction = "get";
        self.url = makeGetBaseUrl();

        if (isOffline())
            return loadFromCache().then(handleSuccess, handleError);

        return axios
            .get(self.url)
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _getMethodCustom(method) {

        self.lastAction = "get";
        self.url = makeGetCustomMethodBaseUrl(method);

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

    function makeGetCustomMethodBaseUrl(method) {
        return String.format("{0}/{1}/{2}", makeUri(), method, queryStringFilter());
    }

    function makeDeleteBaseUrl() {
        return String.format("{0}/?{1}", makeUri(), Object.$httpParamSerializer(self.filters));
    }

    function makeUri() {
        return String.format("{0}/{1}", makeEndPont(), self.Resourse)
    }

    function makeEndPont() {

        if (!self.EndPoint)
            return Constants.END_POINT_DEFAULT;

        return Constants[self.EndPoint];
    }

    function queryStringFilter() {

        if (self.filters.OrderFields !== undefined) {
            self.filters.IsOrderByDynamic = true;
            if (self.filters.OrderByType === undefined)
                self.filters.OrderByType = 1;
        }

        var filter = Object.assign({}, self.defaultFilter, self.filters);

        if (self.filters.Id !== undefined)
            return String.format("{0}?{1}", self.filters.Id, Object.$httpParamSerializer(filter));

        return String.format("?{0}", Object.$httpParamSerializer(filter));
    }

    function handleSuccess(response) { addCache(response.data); }

    function handleError(err) { }

    function addCache(data) {

        if (!self.byCache)
            return;

        if (self.url == "")
            return;

        if (self.lastAction == "get") {
            if (data.Data != null || (data.DataList != null && data.DataList.length > 0)) {
                data = JSON.stringify(data);
                byCache.Add(self.url, data)
            }
        }
    }

    function loadFromCache() {

        if (!self.byCache)
            return;

        var data = byCache.Get(self.url);
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

