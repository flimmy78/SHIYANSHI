// JavaScript source code


        //方向键控制页面控件焦点移动
        function keyDown(event) {
            var colunmIdx = "";
            var inputs = $(".my-textbox")                              //通过class属性值获取控件组合
            var focus = document.activeElement;                 //得到处于激活状态的控件
            if (!document.getElementById("tongdao").contains(focus)) return;     //判断是否包含激活控件在指定的Table下
            //if (!$(".tbl").contains(focus)) return;
            var event = window.event || event;                              //获取事件
            var key = event.keyCode;                                        //得到按下的键盘Ascii码
            var flag = -1;

            //得到激活控件在组合中的具体位置
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i] === focus) {
                    // alert(i);
                    break;
                }
            }

            switch (key) {

                case 37: //向左键
                    if (i > 0) inputs[i - 1].focus();
                    break;
                case 38:                //向上键
                    var td = $(inputs[i]).parents("td").index();      //当前所在的列数
                    var tr = $(inputs[i]).parents("tr");
                    var tr_up = $(inputs[i]).parents("tr").prev();      //当前所在的行数的上一行
                    if ($(inputs[i]).parents("tr").prev().length >= 1) {   //判断上一行是否还有行
                        var tr_up = $("[rowindex=" + ($(tr).attr("rowindex") - 1) + "]", $(inputs[i]).parents("table")[0])[0];      //当前所在的行数的上一行

                        if ($(tr_up).attr("rowindex") == 1)  //如果是第一行
                            $(tr_up).find("td").eq(td + 1).find('input').focus();    //因为有rowspan合并行等,所以如果向上到第一行,则多加一个1;
                        else {
                            if ($(tr).find("td").length < $(tr_up).find("td").length)
                                $(tr_up).find("td").eq(td + 1).find('input').focus();
                            if ($(tr).find("td").length == $(tr_up).find("td").length)
                                $(tr_up).find("td[rowspan='1']").eq(td).find('input').focus();
                            if ($(tr).find("td").length > $(tr_up).find("td").length)
                                $(tr_up).find("td[rowspan='1']").eq(td - 1).find('input').focus();
                        }
                    }
                    else {
                        //没有则找上一个table
                        var prevtable = $(inputs[i]).parents("table").prev()[0];

                        var tr_up = $(prevtable).find("tr:eq(" + ($('tr', $(prevtable)).length - 2) + ")");
                        if ($(tr_up).attr("rowindex") == 1)
                            $(tr_up).find('td').eq(td).find('input').focus();
                        else
                            $(tr_up).find('td').eq(td - 1).find('input').focus();
                    }
                    break;
                case 39: //向右键
                    if (i < inputs.length - 1) inputs[i + 1].focus();
                    break;
                case 40: //向下键
                    var td = $(inputs[i]).parents("td").index();      //当前所在的列数
                    var tr = $(inputs[i]).parents("tr");
                    if ($(inputs[i]).parents("tr").next().length >= 1) {
                        var tr_down = $(inputs[i]).parents("tr").next();      //当前所在的行数的下一行
                        if ($(tr).attr("rowindex") != 1) {
                            if ($(tr).find("td").length < $(tr_down).find("td").length)
                                $(tr_down).find("td").eq(td + 1).find('input').focus();
                            if ($(tr).find("td").length == $(tr_down).find("td").length)
                                $(tr_down).find("td[rowspan='1']").eq(td).find('input').focus();
                            if ($(tr).find("td").length > $(tr_down).find("td").length)
                                $(tr_down).find("td[rowspan='1']").eq(td - 1).find('input').focus();
                        }
                        else
                            $(tr_down).find("td").eq(td - 1).find('input').focus();
                    }
                    else {
                        var table = $(inputs[i]).parents("table").next();
                        var tr = $('[rowindex]', table).eq(0);
                        if ($(tr).attr("rowindex") != 1)
                            $(tr).find('td').eq(td - 1).find('input').focus();
                        else
                            $(tr).find('td').eq(td + 1).find('input').focus();
                    }
                    break;
                case 13:                //回车键
                    event.returnValue = false;                          //阻止自动提交
                    var j = i + 2;
                    var flag = false;
                    if (inputs.get(j).disabled == false) {
                        flag = true;
                    } else {
                        for (j = i + 4; j <= inputs.length - 1; j = j + 2) {
                            if (inputs.get(j).disabled == false) {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag) {
                        inputs[j].focus();
                    }
                    break;
            }
        }
   