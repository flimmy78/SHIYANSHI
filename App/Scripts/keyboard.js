// JavaScript source code


        //���������ҳ��ؼ������ƶ�
        function keyDown(event) {
            var colunmIdx = "";
            var inputs = $(".my-textbox")                              //ͨ��class����ֵ��ȡ�ؼ����
            var focus = document.activeElement;                 //�õ����ڼ���״̬�Ŀؼ�
            if (!document.getElementById("tongdao").contains(focus)) return;     //�ж��Ƿ��������ؼ���ָ����Table��
            //if (!$(".tbl").contains(focus)) return;
            var event = window.event || event;                              //��ȡ�¼�
            var key = event.keyCode;                                        //�õ����µļ���Ascii��
            var flag = -1;

            //�õ�����ؼ�������еľ���λ��
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i] === focus) {
                    // alert(i);
                    break;
                }
            }

            switch (key) {

                case 37: //�����
                    if (i > 0) inputs[i - 1].focus();
                    break;
                case 38:                //���ϼ�
                    var td = $(inputs[i]).parents("td").index();      //��ǰ���ڵ�����
                    var tr = $(inputs[i]).parents("tr");
                    var tr_up = $(inputs[i]).parents("tr").prev();      //��ǰ���ڵ���������һ��
                    if ($(inputs[i]).parents("tr").prev().length >= 1) {   //�ж���һ���Ƿ�����
                        var tr_up = $("[rowindex=" + ($(tr).attr("rowindex") - 1) + "]", $(inputs[i]).parents("table")[0])[0];      //��ǰ���ڵ���������һ��

                        if ($(tr_up).attr("rowindex") == 1)  //����ǵ�һ��
                            $(tr_up).find("td").eq(td + 1).find('input').focus();    //��Ϊ��rowspan�ϲ��е�,����������ϵ���һ��,����һ��1;
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
                        //û��������һ��table
                        var prevtable = $(inputs[i]).parents("table").prev()[0];

                        var tr_up = $(prevtable).find("tr:eq(" + ($('tr', $(prevtable)).length - 2) + ")");
                        if ($(tr_up).attr("rowindex") == 1)
                            $(tr_up).find('td').eq(td).find('input').focus();
                        else
                            $(tr_up).find('td').eq(td - 1).find('input').focus();
                    }
                    break;
                case 39: //���Ҽ�
                    if (i < inputs.length - 1) inputs[i + 1].focus();
                    break;
                case 40: //���¼�
                    var td = $(inputs[i]).parents("td").index();      //��ǰ���ڵ�����
                    var tr = $(inputs[i]).parents("tr");
                    if ($(inputs[i]).parents("tr").next().length >= 1) {
                        var tr_down = $(inputs[i]).parents("tr").next();      //��ǰ���ڵ���������һ��
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
                case 13:                //�س���
                    event.returnValue = false;                          //��ֹ�Զ��ύ
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
   