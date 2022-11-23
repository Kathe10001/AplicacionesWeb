"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.setCookie = exports.getCookie = exports.obtenerFiltrosCalificacion = exports.obtenerParametros = exports.setCalificacion = exports.obtenerBody = exports.obtenerFiltros = void 0;
var obtenerFiltros = function (form, parametros) {
    var filtros = null;
    parametros.forEach(function (param) {
        var _a;
        var _b;
        var paramValor = (_b = form.get(param)) === null || _b === void 0 ? void 0 : _b.value;
        if (paramValor) {
            filtros = __assign(__assign({}, filtros), (_a = {}, _a[param] = paramValor, _a));
        }
    });
    return filtros;
};
exports.obtenerFiltros = obtenerFiltros;
var obtenerBody = function (idUsuario, id, tipo, form, parametros) {
    var filtros = (0, exports.obtenerFiltros)(form, parametros);
    return __assign(__assign({}, filtros), { IdUsuario: idUsuario, Id: id, Tipo: tipo });
};
exports.obtenerBody = obtenerBody;
var setCalificacion = function (form, parametros, data) {
    parametros.forEach(function (param) {
        var _a;
        (_a = form.get(param)) === null || _a === void 0 ? void 0 : _a.setValue(data[param]);
    });
};
exports.setCalificacion = setCalificacion;
var obtenerParametros = function (filtros) {
    var parametros = [];
    filtros && Object.keys(filtros).forEach(function (key) {
        var valor = filtros[key];
        parametros.push(encodeURIComponent(key) + '=' + encodeURIComponent(valor));
    });
    return parametros.length > 0 ? '?' + parametros.join('&') : '';
};
exports.obtenerParametros = obtenerParametros;
var obtenerFiltrosCalificacion = function (idUsuario, id, tipo) { return ({
    Id: id,
    IdUsuario: idUsuario,
    Tipo: tipo
}); };
exports.obtenerFiltrosCalificacion = obtenerFiltrosCalificacion;
var getCookie = function (n, from) {
    var name = n + '=';
    var cDecoded = decodeURIComponent(from);
    var cArr = cDecoded.split('; ');
    var res = '';
    cArr.forEach(function (val) {
        if (val.indexOf(name) === 0)
            res = val.substring(name.length);
    });
    return res;
};
exports.getCookie = getCookie;
var setCookie = function (cName, cValue, expDays) {
    if (expDays === void 0) { expDays = 1; }
    var date = new Date();
    date.setTime(date.getTime() + (expDays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + date.toUTCString();
    document.cookie = cName + "=" + cValue + "; " + expires + "; path=/";
};
exports.setCookie = setCookie;
//# sourceMappingURL=index.js.map