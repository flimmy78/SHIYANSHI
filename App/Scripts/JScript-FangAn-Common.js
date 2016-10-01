

$(document).ready(function () {
    debugger;
    bindShiyanshi("#UNDERTAKE_LABORATORYID");
    if ($("#hideUNDERTAKE_LABORATORYID").val() != "") {
        $("#UNDERTAKE_LABORATORYID").val($("#hideUNDERTAKE_LABORATORYID").val()).change();
        ChangeTree($("#hideUNDERTAKE_LABORATORYID").val());
    }
    $('#UNDERTAKE_LABORATORYID').combobox({
        onChange: function (n, o) {
            ChangeTree(n);
        }
    });
    TreeLoad();
});
//加载树
function TreeLoad() {
    //多选框选中
    var RuleIDs = $("#RuleIDs").val();
    if (RuleIDs != null && RuleIDs.trim() != "") {
        var roots = $('#tt').tree('getChildren');
        for (var i = 0; i < roots.length; i++) {
            if (RuleIDs.indexOf('/' + roots[i].id + '/') >= 0) {
                $('#tt').tree('check', roots[i].target);
            }
        }
    }
    $('#tt').tree({
        onClick: function (node) {            
            var ID = $("#hideID").val();
            if ($('#tt').tree('isLeaf', node.target)) {
                if (node.attributes != null && node.attributes.url != null && node.attributes.url.trim() != "") {
                    if ($('#tt').tree('isLeaf', node.target)) {
                        if (node.checked == false) {
                            $.messager.alert('操作提示', '未勾选【' + node.text + '】检测项无法设置具体内容！', 'warning');
                        }
                        else if (ID.trim() == "") {
                            $.messager.alert('操作提示', '请先提交方案模板', 'warning');
                        }
                        else {
                            $('#mainframe').attr('src', node.attributes.url + "&SCHEMEID=" + ID);
                        }
                    }
                }
            }
        }
    });
}
//实验室调整变更树内容
//ShiYanShiID:实验室ID
function ChangeTree(ShiYanShiID) {
    debugger;
    var url = ShiYanShiShuXing(ShiYanShiID, "treeUrl");
    if (url == null || url.trim() == "") {
        url = "/Res/tree_data1.js";
    }
    $('#tt').tree({
        url: url
    });

}
//数据验证
function CheckData() {

    var NAME = $("#NAME").val();//方案名称   
    if ($.trim(NAME) == "") {
        $.messager.alert('操作提示', '请填写方案名称!', 'warning');
        return false;
    }
    var nodes = $('#tt').tree('getChecked');//检测项是否选择
    var IsHaveData = false;
    if (nodes.length > 0) {
        for (var i = 0; i < nodes.length; i++) {
            if ($('#tt').tree('isLeaf', nodes[i].target))//是否是最末节点
            {
                IsHaveData = true;
                break;
            }
        }
    }
    if (!IsHaveData) {
        $.messager.alert('操作提示', '请选择检测项!', 'warning');
        return false;
    }
    return true;
}
//保存
function Save() {
    if (!CheckData()) {
        return;
    }
    var UNDERTAKE_LABORATORYID = $("#UNDERTAKE_LABORATORYID").val();//实验室
    var NAME = $("#NAME").val();//方案名称           
    var nodes = $('#tt').tree('getChecked');
    var RULEIDs = '';
    for (var i = 0; i < nodes.length; i++) {
        var node = nodes[i];
        if ($('#tt').tree('isLeaf', node.target)) {
            if (RULEIDs != '') RULEIDs += ',';
            RULEIDs += node.id;
        }
    }
    var ID = $("#hideID").val();
    var OP = $("#hideOP").val();//操作
    var COPYID = $("#hideCOPYID").val();//复制方案ID
    //获取空对象用于保存添加的信息
    $.ajax({
        type: 'post', //使用post方法访问后台
        dataType: "json", //返回json格式的数据       
        url: '/SCHEME/Save',//要访问的后台地址
        contentType: 'application/x-www-form-urlencoded; charset=utf-8', //指定编码方式       
        data: { 'ID': ID, 'NAME': NAME, 'UNDERTAKE_LABORATORYID': UNDERTAKE_LABORATORYID, 'RULEIDs': RULEIDs, 'OP': OP, 'COPYID': COPYID },//要发送的数据
        beforeSend: function () {
            //InitAlertJS();
        },
        complete: function () {
        }, //AJAX请求完成时隐藏loading提示

        success: function (res) {//msg为返回的数据，在这里做数据绑定               
            if (res.Code == 1) {
                if ($("#hideID").val().trim() == "") {
                    $("#hideID").val(res.Message);
                }
                $.messager.alert('操作提示', "操作成功！", 'info');
            }
            else {
                $.messager.alert('操作提示', res.Message, 'info');
            }
            if ($("#hideID").val() != "") {
                $("#UNDERTAKE_LABORATORYID").attr("disabled", "disabled");
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.messager.alert('操作提示', '操作失败!' + errorThrown.messager, 'warning');
        }
    });
}
