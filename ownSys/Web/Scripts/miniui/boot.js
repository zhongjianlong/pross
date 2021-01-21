﻿
__CreateJSPath = function (js) {
    var scripts = document.getElementsByTagName("script");
    var path = "";
    for (var i = 0, l = scripts.length; i < l; i++) {
        var src = scripts[i].src;
        if (src.indexOf(js) != -1) {
            var ss = src.split(js);
            path = ss[0];
            break;
        }
    }
    var href = location.href;
    href = href.split("#")[0];
    href = href.split("?")[0];
    var ss = href.split("/");
    ss.length = ss.length - 1;
    href = ss.join("/");
    if (path.indexOf("https:") == -1 && path.indexOf("http:") == -1 && path.indexOf("file:") == -1 && path.indexOf("\/") != 0) {
        path = href + "/" + path;
    }
    RootPath = path.replace("/scripts/", "") + "/";
    return path;
}
var RootPath;
var bootPATH = __CreateJSPath("boot.js");

//debugger
mini_debugger = true;   

//miniui   
document.write('<script src="' + bootPATH + 'jquery-1.8.0.js" type="text/javascript"></sc' + 'ript>');
document.write('<script src="' + bootPATH + 'miniui/themes/miniui.js" type="text/javascript" ></sc' + 'ript>');
document.write('<script src="' + bootPATH + 'upperCase.js" type="text/javascript" ></sc' + 'ript>');
document.write('<script src="' + bootPATH + 'common.js" type="text/javascript"></sc' + 'ript>');
document.write('<link href="' + bootPATH + 'miniui/themes/default/miniui.css" rel="stylesheet" type="text/css" />');
document.write('<link href="' + bootPATH + 'miniui/themes/icons.css" rel="stylesheet" type="text/css" />');
//document.write('<link href="' + bootPATH + '../style/commonStyle.css" rel="stylesheet" type="text/css" />');
document.write('<link href="' +bootPATH + '../style/common.css" rel="stylesheet" type="text/css" />');

function getQueryString(name, url) {
    var str = location.search;
    if (arguments.length == 2) str = url;
    var svalue = str.match(new RegExp("[\?\&]" + name + "=([^\&]*)(\&?)", "i"));
    return svalue ? unescape(svalue[1]) : svalue;
}

//skin
var skin = getCookie("miniuiSkin");
if (skin) {
    document.write('<link href="' + bootPATH + 'miniui/themes/' + skin + '/skin.css" rel="stylesheet" type="text/css" />');
}else {
    document.write('<link href="' + bootPATH + 'miniui/themes/' + 'metro-white' + '/skin.css" rel="stylesheet" type="text/css" />');

}

// 语言类型
var langType = getCookie("langType");
if (langType === null || langType=="en") {
    document.write('<script src="' + bootPATH + 'miniui/locale/en_US.js" type="text/javascript" ></sc' + 'ript>');
}

////////////////////////////////////////////////////////////////////////////////////////
function getCookie(sName) {
    var aCookie = document.cookie.split("; ");
    var lastMatch = null;
    for (var i = 0; i < aCookie.length; i++) {
        var aCrumb = aCookie[i].split("=");
        if (sName == aCrumb[0]) {
            lastMatch = aCrumb;
        }
    }
    if (lastMatch) {
        var v = lastMatch[1];
        if (v === undefined) return v;
        return unescape(v);
    }
    return null;
}