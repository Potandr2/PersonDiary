"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var CommonUtils = /** @class */ (function () {
    function CommonUtils() {
    }
    CommonUtils.correctDate2UTC = function (date) {
        if (typeof date === "string")
            date = new Date(date);
        return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate()));
    };
    CommonUtils.getErorrMessagesText = function (messages) {
        var result = "";
        messages.filter(function (m) { return m.type == 1; }).forEach(function (m) { return result += m.text; });
        return result;
    };
    return CommonUtils;
}());
exports.CommonUtils = CommonUtils;
//# sourceMappingURL=common.utils.js.map