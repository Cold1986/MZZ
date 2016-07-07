
//全选反选
$(function () {
    $("#chk_all").click(function () {
        $('input[name="chk_list"]').attr("checked", this.checked);
    });
    var $subBox = $("input[name='chk_list']");
    $subBox.click(function () {
        $("#chk_all").attr("checked", $subBox.length == $("input[name='chk_list']:checked").length ? true : false);
    });
});

//a标签删除
function adelete(pageurl) {
    if ($("input[name='chk_list']:checked").length <= 0) {
        alert("请选择要删除行!");
        return false;
    }
    document.forms[0].action = pageurl;
    document.forms[0].method = "post";
    document.forms[0].submit();
}

//只能输入数字
function datavalid() {
    var keyCode = event.keyCode; //获得输入的ASC码
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 96 && keyCode <= 105) || keyCode == 8) { //判断是否数字
        event.returnValue = true; //事件返回值onkeydown="return datavalid();"
    }
    else {
        event.returnValue = false;
    }
}

function clearNoNum(obj) {
    obj.value = obj.value.replace(/[^\d.]/g, ""); //清除"数字"和"."以外的字符
    obj.value = obj.value.replace(/^\./g, ""); //验证第一个字符是数字而不是
    obj.value = obj.value.replace(/\.{2,}/g, "."); //只保留第一个. 清除多余的
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
    obj.value = obj.value.replace(/^(\-)*(\d+)\.(\d\d).*$/, '$1$2.$3'); //只能输入两个小数
}