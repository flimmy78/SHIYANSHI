//---------------------------------
//每行不确定度计算按钮
var JiSuanBuQueDingDu_MeiHang_Html = " <a href=\"javascript:void(0)\" class=\"easyui-linkbutton\" data-options=\"plain:true,iconCls:'icon-save'\">计算不确定度</a>";
//检测项目单位
var DanWeiDDLHtmlArray = Array;
DanWeiDDLHtmlArray = [
           {
               Code: 'JiaoZhiLiuSelect',
               Remark: '交直流选择DC,AC',
               Value: "<select class=\"my-combobox\" name=\"JiaoZhiLiuSelect\" style=\"width:50px; \">" +
                       "<option value=\"DC\">DC</option> " +
                       "<option value=\"AC\">AC</option>" +
                      "</select>"
           },
           {
               Code: 'ZhiHouChaoQian',
               Remark: '滞后',
               Value: "<select class=\"my-combobox\" name=\"ZhiHouChaoQian\" style=\"width:50px; \">" +
                       "<option value=\"滞后\">滞后</option> " +
                       "<option value=\"超前\">超前</option>" +
                      "</select>"
           }, {
               Code: 'EDGZDianliu100',
               Remark: '额定工作电流',
               Value: "<select class=\"my-combobox\" name=\"EDGZDianliu\" style=\"width:70px; \">" +
                       "<option value=\"100\">100</option> " +
                        "<option value=\"100/√3\">100/√3\</option> " +
                      "</select>"
           }
        , {
              Code: 'EDGZDianliu',
              Remark: '额定工作电流',
              Value: "<select class=\"my-combobox\" name=\"EDGZDianliu\" style=\"width:50px; \">" +
                      "<option value=\"5\">5</option> " +
                      "<option value=\"1\">1</option>" +
                     "</select>"
          }
        , {
            Code: 'JieLun',
            Remark: '结论',
            Value: "<select class=\"my-combobox\" name=\"JieLun\" style=\"width:50px; \">" +
                    "<option value=\"合格\">合格</option> " +
                    "<option value=\"不合格\">不合格</option>" +
                   "</select>"
        }
         , {
             Code: 'DianLiuBaiFenBi',
             Remark: '额定电流百分比',
             Value: "<select class=\"my-combobox\" name=\"DianLiuBaiFenBi\" style=\"width:70px; \">" +
                     "<option value=\"1%\">1%</option> " +
                     "<option value=\"5%\">5%</option>" +
                     "<option value=\"20%\">20%</option> " +
                     "<option value=\"50%\">50%</option>" +
                     "<option value=\"80%\">80%</option> " +
                     "<option value=\"100%\">100%</option>" +
                    "<option value=\"120%\">120%</option> " +

                    "</select>"
         }
   ,
  {
                Code: 'Cos',
                Remark: 'cosθ',
                Value: "<select class=\"my-combobox\" name=\"Cos\" style=\"width:79px; \">" +
                        "<option value=\"1.0\">1.0</option> " +
                         "<option value=\"0.5L\">0.5L</option>" +
                        "</select>"
            },
       {
           Code: 'XiangBie',
           Remark: '相别',
           Value: "<select class=\"my-combobox\" name=\"XiangBie\" style=\"width:79px; \">" +
                   "<option value=\"A相\">A相</option> " +
                    "<option value=\"B相\">B相</option>" +
                    "<option value=\"C相\">C相</option>  " +
                   "</select>"
       }, {
         Code: 'Ib',
         Remark: 'Ib(%)',
         Value: "<select class=\"my-combobox\" name=\"Ib\" style=\"width:79px; \">" +
                 "<option value=\"100\">100</option> " +
                  "<option value=\"50\">50</option>" +
                  "<option value=\"20\">20</option>  " +
                 "<option value=\"10\">10</option>  " +
                 "<option value=\"5\">5</option>  " +
                 "</select>"
     },
    {
        Code: 'GongLvYinShu',
        Remark: '功率因数cosφ',
        Value: "<select class=\"my-combobox\" name=\"GongLvYinShu\" style=\"width:79px; \">" +
                "<option value=\"1.0\">1.0</option> " +
                 "<option value=\"0.5L\">0.5L</option>" +
                 "<option value=\"0.8C\">0.8C</option>  " +
                "<option value=\"0.5C\">0.5C</option>  " +
                "<option value=\"0.25L\">0.25L</option>  " +
                "</select>"
    },
    {
        Code: 'XiangXianJiCeLiangMoShi',
        Remark: '相线及测量模式',
        Value: "<select class=\"my-combobox\" name=\"XiangXianJiCeLiangMoShi\" style=\"width:79px; \">" +
                "<option value=\"单相\">单相</option> " +
                 "<option value=\"三相三线\">三相三线</option>" +
                 "<option value=\"三相四线\">三相四线</option>  " +
                "</select>"
    }, {
         Code: 'EDingDianYa',
         Remark: '额定电压',
         Value: "<select class=\"my-combobox\" name=\"EDingDianYa\" style=\"width:79px; \">" +
                 "<option value=\"50\">50</option> " +
                  "<option value=\100\">100</option>" +
                  "<option value=\"250\">250</option>  " +
                  "<option value=\"500\">500</option>  " +
                  "<option value=\"1000\">1000</option>  " +
                  "<option value=\"2500\">2500</option>  " +
                  "<option value=\"5000\">5000</option>  " +
                 "</select>"
     },
    {
        Code: 'DianLiu',
        Remark: '电流单位',
        Value: "<select class=\"my-combobox\" name=\"DianLiu\" style=\"width:50px; \">" +
                "<option value=\"A\">A</option> " +
                 "<option value=\"kA\">kA</option>" +
                 "<option value=\"mA\">mA</option>  " +
                 "<option value=\"μA\">μA</option>" +
                 "<option value=\"nA\">nA</option> " +
                 "<option value=\"pA\">pA</option> " +
                "</select>"
    },
        {
            Code: 'DianYa',
            Remark: '电压单位',
            Value: "<select class=\"my-combobox\" name=\"DianYa\" style=\"width:50px; \">" +
                    "<option value=\"V\">V</option> " +
                    "<option value=\"MV\">MV</option>" +
                    "<option value=\"kV\">kV</option>  " +
                    "<option value=\"mV\">mV</option>" +
                    "<option value=\"μV\">μV</option> " +
                   "</select>"
        }
        ,
        {
            Code: 'DYDL',
            Remark: '电压单位',
            Value: "<select class=\"my-combobox\" name=\"DianYa\" style=\"width:50px; \">" +
                    "<option value=\"V\">V</option> " +
                    "<option value=\"MV\">MV</option>" +
                    "<option value=\"kV\">kV</option>  " +
                    "<option value=\"mV\">mV</option>" +
                    "<option value=\"μV\">μV</option> " +
                    "<option value=\"A\">A</option> " +
                    "<option value=\"kA\">kA</option>" +
                    "<option value=\"mA\">mA</option>  " +
                    "<option value=\"μA\">μA</option>" +
                    "<option value=\"nA\">nA</option> " +
                    "<option value=\"pA\">pA</option> " +
                   "</select>"
        }
        ,
        {
            Code: 'DianLiuKA',
            Remark: '电流单位KA开头',
            Value: "<select class=\"my-combobox\" name=\"DianLiuKA\" style=\"width:50px; \">" +
                    "<option value=\"kA\">kA</option> " +
                    "<option value=\"A\">A</option>" +
                    "<option value=\"mA\">mA</option>  " +
                    "<option value=\"μA\">μA</option>" +
                    "<option value=\"nA\">nA</option> " +
                    "<option value=\"pA\">pA</option> " +
                   "</select>"
        }
            ,
        {
            Code: 'LC',
            Remark: 'LC空格',
            Value: "<select class=\"my-combobox\" name=\"LC\">" +
                    "<option value=\"L\">L</option> " +
                    "<option value=\" \"> </option>" +
                    "<option value=\"C\">C</option>  " +
                    "</select>"
        }
                ,
        {
            Code: 'BuQueDingDu',
            Remark: '不确定度',
            Value: "<select class=\"my-combobox\" name=\"LC\" style=\"width:50px; \">" +
                    "<option value=\"2\">2</option> " +
                    "<option value=\"3\">3</option>" +
                    "<option value=\"√3\">√3</option>  " +
                    "</select>"
        }
        ,
        {
            Code: 'TongDaoU0',
            Remark: '通道范围U0开头',
            Value: "<select class=\"my-combobox\" name=\"TongDaoU0\" style=\"width:50px; \">" +
                    "<option value=\"U0\">U0</option> " +
                    "<option value=\"U1\">U1</option>" +
                    "<option value=\"U2\">U2</option>  " +
                    "<option value=\"U3\">U3</option>" +
                    "<option value=\"U4\">U4</option> " +
                    "<option value=\"U5\">U5</option> " +
                    "<option value=\"U6\">U6</option> " +
                    "<option value=\"U7\">U7</option> " +
                    "<option value=\"U8\">U8</option> " +
                    "<option value=\"U9\">U9</option> " +
                    "<option value=\"U10\">U10</option> " +
                    "<option value=\"U11\">U11</option> " +
                    "<option value=\"U12\">U12</option> " +
                    "<option value=\"U13\">U13</option> " +
                    "<option value=\"U14\">U14</option> " +
                    "<option value=\"U15\">U15</option> " +
                    "<option value=\"U16\">U16</option> " +
                    "<option value=\"U17\">U17</option> " +
                    "<option value=\"U18\">U18</option> " +
                    "<option value=\"U19\">U19</option> " +
                    "<option value=\"U20\">U20</option> " +

                    "<option value=\"CH0\">CH0</option> " +
                    "<option value=\"CH1\">CH1</option>" +
                    "<option value=\"CH2\">CH2</option>  " +
                    "<option value=\"CH3\">CH3</option>" +
                    "<option value=\"CH4\">CH4</option> " +
                    "<option value=\"CH5\">CH5</option> " +
                    "<option value=\"CH6\">CH6</option> " +
                    "<option value=\"CH7\">CH7</option> " +
                    "<option value=\"CH8\">CH8</option> " +
                    "<option value=\"CH9\">CH9</option> " +
                    "<option value=\"CH10\">CH10</option> " +
                    "<option value=\"CH11\">CH11</option> " +
                    "<option value=\"CH12\">CH12</option> " +
                    "<option value=\"CH13\">CH13</option> " +
                    "<option value=\"CH14\">CH14</option> " +
                    "<option value=\"CH15\">CH15</option> " +
                    "<option value=\"CH16\">CH16</option> " +

                     "<option value=\"UA1\">UA1</option> " +
                    "<option value=\"UA2\">UA2</option>" +
                    "<option value=\"UA3\">UA3</option>  " +
                    "<option value=\"UA4\">UA4</option>" +
                    "<option value=\"UA5\">UA5</option> " +
                    "<option value=\"UA6\">UA6</option> " +

                     "<option value=\"UB1\">UB1</option> " +
                    "<option value=\"UB2\">UB2</option>" +
                    "<option value=\"UB3\">UB3</option>  " +
                    "<option value=\"UB4\">UB4</option>" +
                    "<option value=\"UB5\">UB5</option> " +
                    "<option value=\"UB6\">UB6</option> " +

                     "<option value=\"UC1\">UC1</option> " +
                    "<option value=\"UC2\">UC2</option>" +
                    "<option value=\"UC3\">UB3</option>  " +
                    "<option value=\"UC4\">UC4</option>" +
                    "<option value=\"UC5\">UC5</option> " +
                    "<option value=\"UC6\">UC6</option> " +

                     "<option value=\"U01\">U01</option> " +
                    "<option value=\"U02\">U02</option>" +
                    "<option value=\"U03\">U03</option>  " +
                    "<option value=\"U04\">U04</option>" +
                    "<option value=\"U05\">U05</option> " +
                    "<option value=\"U06\">U06</option> " +
                   "</select>"
        }

           ,
        {
            Code: 'TongDaoU0UA',
            Remark: '通道范围U0UA开头',
            Value: "<select class=\"my-combobox\" name=\"TongDaoU0UA\" style=\"width:50px; \">" +
                    "<option value=\"U0\">U0</option> " +
                    "<option value=\"U1\">U1</option>" +
                    "<option value=\"U2\">U2</option>  " +
                    "<option value=\"U3\">U3</option>" +
                    "<option value=\"U4\">U4</option> " +
                    "<option value=\"U5\">U5</option> " +
                    "<option value=\"U6\">U6</option> " +
                    "<option value=\"U7\">U7</option> " +
                    "<option value=\"U8\">U8</option> " +
                    "<option value=\"U9\">U9</option> " +
                    "<option value=\"U10\">U10</option> " +
                    "<option value=\"U11\">U11</option> " +
                    "<option value=\"U12\">U12</option> " +
                    "<option value=\"U13\">U13</option> " +
                    "<option value=\"U14\">U14</option> " +
                    "<option value=\"U15\">U15</option> " +
                    "<option value=\"U16\">U16</option> " +
                    "<option value=\"U17\">U17</option> " +
                    "<option value=\"U18\">U18</option> " +
                    "<option value=\"U19\">U19</option> " +
                    "<option value=\"U20\">U20</option> " +

                    "<option value=\"CH0\">CH0</option> " +
                    "<option value=\"CH1\">CH1</option>" +
                    "<option value=\"CH2\">CH2</option>  " +
                    "<option value=\"CH3\">CH3</option>" +
                    "<option value=\"CH4\">CH4</option> " +
                    "<option value=\"CH5\">CH5</option> " +
                    "<option value=\"CH6\">CH6</option> " +
                    "<option value=\"CH7\">CH7</option> " +
                    "<option value=\"CH8\">CH8</option> " +
                    "<option value=\"CH9\">CH9</option> " +
                    "<option value=\"CH10\">CH10</option> " +
                    "<option value=\"CH11\">CH11</option> " +
                    "<option value=\"CH12\">CH12</option> " +
                    "<option value=\"CH13\">CH13</option> " +
                    "<option value=\"CH14\">CH14</option> " +
                    "<option value=\"CH15\">CH15</option> " +
                    "<option value=\"CH16\">CH16</option> " +

                     "<option value=\"UA1\">UA1</option> " +
                    "<option value=\"UA2\">UA2</option>" +
                    "<option value=\"UA3\">UA3</option>  " +
                    "<option value=\"UA4\">UA4</option>" +
                    "<option value=\"UA5\">UA5</option> " +
                    "<option value=\"UA6\">UA6</option> " +

                     "<option value=\"UB1\">UB1</option> " +
                    "<option value=\"UB2\">UB2</option>" +
                    "<option value=\"UB3\">UB3</option>  " +
                    "<option value=\"UB4\">UB4</option>" +
                    "<option value=\"UB5\">UB5</option> " +
                    "<option value=\"UB6\">UB6</option> " +

                     "<option value=\"UC1\">UC1</option> " +
                    "<option value=\"UC2\">UC2</option>" +
                    "<option value=\"UC3\">UB3</option>  " +
                    "<option value=\"UC4\">UC4</option>" +
                    "<option value=\"UC5\">UC5</option> " +
                    "<option value=\"UC6\">UC6</option> " +

                     "<option value=\"U01\">U01</option> " +
                    "<option value=\"U02\">U02</option>" +
                    "<option value=\"U03\">U03</option>  " +
                    "<option value=\"U04\">U04</option>" +
                    "<option value=\"U05\">U05</option> " +
                    "<option value=\"U06\">U06</option> " +

                     "<option value=\"UA\">UA</option> " +
                    "<option value=\"UB\">UB</option>" +
                    "<option value=\"UC\">UC</option>  " +
                    "<option value=\"Ua\">Ua</option>" +
                    "<option value=\"Ub\">Ub</option> " +
                    "<option value=\"Uc\">Uc</option> " +
                   "</select>"
        }
          ,
        {
            Code: 'TongDaoI0',
            Remark: '通道范围I0开头',
            Value: "<select class=\"my-combobox\" name=\"TongDaoI0\" style=\"width:50px; \">" +
                    "<option value=\"I0\">I0</option> " +
                    "<option value=\"I1\">I1</option>" +
                    "<option value=\"I2\">I2</option>  " +
                    "<option value=\"I3\">I3</option>" +
                    "<option value=\"I4\">I4</option> " +
                    "<option value=\"I5\">I5</option> " +
                    "<option value=\"I6\">I6</option> " +
                    "<option value=\"I7\">I7</option> " +
                    "<option value=\"I8\">I8</option> " +
                    "<option value=\"I9\">I9</option> " +
                    "<option value=\"I10\">I10</option> " +
                    "<option value=\"I11\">I11</option> " +
                    "<option value=\"I12\">I12</option> " +
                    "<option value=\"I13\">I13</option> " +
                    "<option value=\"I14\">I14</option> " +
                    "<option value=\"I15\">I15</option> " +
                    "<option value=\"I16\">I16</option> " +
                    "<option value=\"I17\">I17</option> " +
                    "<option value=\"I18\">I18</option> " +
                    "<option value=\"I19\">I19</option> " +
                    "<option value=\"I20\">I20</option> " +

                    "<option value=\"CH0\">CH0</option> " +
                    "<option value=\"CH1\">CH1</option>" +
                    "<option value=\"CH2\">CH2</option>  " +
                    "<option value=\"CH3\">CH3</option>" +
                    "<option value=\"CH4\">CH4</option> " +
                    "<option value=\"CH5\">CH5</option> " +
                    "<option value=\"CH6\">CH6</option> " +
                    "<option value=\"CH7\">CH7</option> " +
                    "<option value=\"CH8\">CH8</option> " +
                    "<option value=\"CH9\">CH9</option> " +
                    "<option value=\"CH10\">CH10</option> " +
                    "<option value=\"CH11\">CH11</option> " +
                    "<option value=\"CH12\">CH12</option> " +
                    "<option value=\"CH13\">CH13</option> " +
                    "<option value=\"CH14\">CH14</option> " +
                    "<option value=\"CH15\">CH15</option> " +
                    "<option value=\"CH16\">CH16</option> " +

                     "<option value=\"IA1\">IA1</option> " +
                    "<option value=\"IA2\">IA2</option>" +
                    "<option value=\"IA3\">IA3</option>  " +
                    "<option value=\"IA4\">IA4</option>" +
                    "<option value=\"IA5\">IA5</option> " +
                    "<option value=\"IA6\">IA6</option> " +

                     "<option value=\"IB1\">IB1</option> " +
                    "<option value=\"IB2\">IB2</option>" +
                    "<option value=\"IB3\">IB3</option>  " +
                    "<option value=\"IB4\">IB4</option>" +
                    "<option value=\"IB5\">IB5</option> " +
                    "<option value=\"IB6\">IB6</option> " +

                     "<option value=\"IC1\">IC1</option> " +
                    "<option value=\"IC2\">IC2</option>" +
                    "<option value=\"IC3\">IB3</option>  " +
                    "<option value=\"IC4\">IC4</option>" +
                    "<option value=\"IC5\">IC5</option> " +
                    "<option value=\"IC6\">IC6</option> " +

                     "<option value=\"I01\">I01</option> " +
                    "<option value=\"I02\">I02</option>" +
                    "<option value=\"I03\">I03</option>  " +
                    "<option value=\"I04\">I04</option>" +
                    "<option value=\"I05\">I05</option> " +
                    "<option value=\"I06\">I06</option> " +
                   "</select>"
        }
            ,
        {
            Code: 'TongDaoUAB',
            Remark: '通道范围UAB开头',
            Value: "<select class=\"my-combobox\" name=\"TongDaoUAB\" style=\"width:50px; \">" +
                    "<option value=\"UAB\">UAB</option> " +
                    "<option value=\"UBC\">UBC</option>" +
                    "<option value=\"U1\">U1</option>  " +
                    "<option value=\"U2\">U2</option>" +
                   "</select>"
        }
              ,
        {
            Code: 'TongDaoI1',
            Remark: '通道范围I1开头',
            Value: "<select class=\"my-combobox\" name=\"TongDaoI1\" style=\"width:50px; \">" +
                    "<option value=\"I1\">I1</option> " +
                    "<option value=\"I2\">I2</option>" +
                   "</select>"
        }
               ,
        {
            Code: 'TongDaoUA',
            Remark: '通道范围UA开头',
            Value: "<select class=\"my-combobox\" name=\"TongDaoUA\" style=\"width:50px; \">" +
                    "<option value=\"UA\">UA</option> " +
                    "<option value=\"UB\">UB</option>" +
                    "<option value=\"UC\">UC</option>  " +
                   "</select>"
        }
               ,
        {
            Code: 'HZ',
            Remark: '赫兹',
            Value: "<select class=\"my-combobox\" name=\"HZ\" >" +
                    "<option value=\"Hz\">Hz</option> " +
                    "<option value=\"kHz\">kHz</option>" +
                    "<option value=\"MHz\">MHz</option>  " +
                    "<option value=\"GHz\">GHz</option>  " +
                    "<option value=\"\"></option>  " +
                   "</select>"
        }
                  ,
        {
            Code: 'OM',
            Remark: '欧姆',
            Value: "<select class=\"my-combobox\" name=\"OM\" >" +
                    "<option value=\"Ω\">Ω</option> " +
                    "<option value=\"TΩ\">TΩ</option>" +
                    "<option value=\"GΩ\">GΩ</option>  " +
                    "<option value=\"MΩ\">MΩ</option>  " +
                    "<option value=\"kΩ\">kΩ</option>  " +
                    "<option value=\"mΩ\">mΩ</option>  " +
                    "<option value=\"μΩ\">μΩ</option>  " +
                   "</select>"
        }
]
//检测项控制属性
var RuleAttributeArray = new Array;
RuleAttributeArray = [{
    RuleID: 'test',//检测项编号
    Remark: '直流电流输出-相对误差',//检测项说明
    Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'hidden',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;DianYa|ACTUALVALUE',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: ',READVALUE,',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'

        }]
}
    ,
    {
        RuleID: '38-1987_2_1',//检测项编号
        Remark: '直流电流输出-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;DYDL|ACTUALVALUE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;OUTPUTVALUE;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'G'
            }]
    }
    ,
    {
        RuleID: 'd38-1987_2_1',//检测项编号
        Remark: '直流电流输出-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;DYDL|ACTUALVALUE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;OUTPUTVALUE;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '38-1987_2_2',//检测项编号
        Remark: '直流电流输出-绝对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RELATIVEERROR,DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;DYDL|ACTUALVALUE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)ACTUALVALUE
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;OUTPUTVALUE;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)     
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '724-1991_2_1',//检测项编号
        Remark: '直流电阻测量-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'OM|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '724-1991_2_2',//检测项编号
        Remark: '直流电阻测量-绝对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'OM|RANGE,READVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '724-1991_2_3',//检测项编号
        Remark: '直流电阻输出-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'OM|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
     
      ,
    {
        RuleID: '724-1991_2_4',//检测项编号
        Remark: '直流电阻输出-绝对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'OM|RANGE,READVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '445-1986_2_2',//检测项编号
        Remark: '直流电压输出-绝对误差',//检测项说明2
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,RELATIVEERROR,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,RELATIVEERROR,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',

                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '315-1983_2_1',//检测项编号
        Remark: '直流电压测量-非正负极性-相对误差（单相）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                //JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '315-1983_2_2',//检测项编号
        Remark: '直流电压测量-非正负极性-相对误差（多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '598-1989_2_3',//检测项编号
        Remark: '直流电流测量-非正负极性-相对误差（单相）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                //JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '598-1989_2_4',//检测项编号
        Remark: '直流电流测量-非正负极性-相对误差（多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '445-1986_2_1',//检测项编号
        Remark: '直流电压输出-非正负极性-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: 'd445-1986_2_1',//检测项编号
        Remark: '直流电压输出-非正负极性-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '315-1983_2_3',//检测项编号
        Remark: '直流电压测量-正负极性-相对误差（单相）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                //JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '315-1983_2_5',//检测项编号
        Remark: '直流电压测量-正负极性-相对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,RELATIVEERROR,RELATIVEERRORFU,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,RELATIVEERROR,RELATIVEERRORFU,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '315-1983_2_4',//检测项编号
        Remark: '直流电压测量-正负极性-相对误差（多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: 'd315-1983_2_4',//检测项编号
        Remark: '直流电压测量-正负极性-相对误差（多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '598-1989_2_1',//检测项编号
        Remark: '直流电流测量-正负极性-相对误差（单相）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                //JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '598-1989_2_6',//检测项编号
        Remark: '直流电流测量-正负极性-相对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,RELATIVEERROR,RELATIVEERRORFU,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,RELATIVEERROR,RELATIVEERRORFU,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '598-1989_2_2',//检测项编号
        Remark: '直流电流测量-正负极性-相对误差（多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: 'd598-1989_2_2',//检测项编号
        Remark: '直流电流测量-正负极性-相对误差（多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,SHIJISHUCHUZHIFU,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '603-2006_3_2_1',//检测项编号
        Remark: '频率输出-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'HZ|OUTPUTVALUE,READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:SHIJISHUCHUZHI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '603-2006_3_1_1',//检测项编号
        Remark: '频率测量-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'HZ|OUTPUTVALUE,READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '410-1994_6_1',//检测项编号
        Remark: '交流电压输出-电压误差-两相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYASHUCHU1,DIANYASHUCHU2,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '34-1999_3_3',//检测项编号
        Remark: '交流电压测量-交流电压测量-两相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '34-1999_3_4',//检测项编号
        Remark: '交流电压测量-相对误差-两相-多通道',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '35-1999_3_3',//检测项编号
        Remark: '交流电流测量-相对误差-两相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '35-1999_3_4',//检测项编号
        Remark: '交流电流测量-相对误差-两相-多通道',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '51-1999_3_1',//检测项编号
        Remark: '交流电流输出-相对误差-两相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYASHUCHU1,DIANYASHUCHU2,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
      ,
    {
        RuleID: '51-1999_3_3',//检测项编号
        Remark: '交流电流输出-相对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE;DianLiu|READVALUE;HZ|HZMY;DYDL|ACTUALVALUE;DianLiu|SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;OUTPUTVALUE;READVALUE;HZMY;',

                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
      ,
    {
        RuleID: '51-1999_3_4',//检测项编号
        Remark: '交流电流输出-绝对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|READVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|RANGE,READVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;HZ|HZMY;DianYa|ACTUALVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',READVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;RANGE;K;;READVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '410-1994_6_2',//检测项编号
        Remark: '交流电压输出-相对误差-三相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYASHUCHU1,DIANYASHUCHU2,DIANYASHUCHU3,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '34-1999_3_5',//检测项编号
        Remark: '交流电压测量-相对误差-三相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,DIANYACELIANG3,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '34-1999_3_6',//检测项编号
        Remark: '交流电压测量-相对误差-三相-多通道',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,DIANYACELIANG3,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '35-1999_3_5',//检测项编号
        Remark: '交流电流测量-相对误差-三相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,DIANYACELIANG3,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '51-1999_3_2',//检测项编号
        Remark: '交流电流输出-相对误差-三相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYASHUCHU1,DIANYASHUCHU2,DIANYASHUCHU3,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '35-1999_3_6',//检测项编号
        Remark: '交流电流测量-相对误差-三相-多通道',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',DIANYACELIANG1,DIANYACELIANG2,DIANYACELIANG3,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '34-1999_3_1',//检测项编号
        Remark: '交流电压测量-相对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                //JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '34-1999_3_2',//检测项编号
        Remark: '交流电压测量-相对误差-单相多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: 'd34-1999_3_2',//检测项编号
        Remark: '交流电压测量-相对误差-单相多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '35-1999_3_1',//检测项编号
        Remark: '交流电流测量-相对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '35-1999_3_2',//检测项编号
        Remark: '交流电流测量-相对误差-单相多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: 'd35-1999_3_2',//检测项编号
        Remark: '交流电流测量-相对误差-单相多通道）',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '34-1999_3_7',//检测项编号
        Remark: '交流电压测量-绝对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '35-1999_3_7',//检测项编号
        Remark: '交流电流测量-绝对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',

                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '410-1994_6_3',//检测项编号
        Remark: '交流电压输出-相对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE,ACTUALVALUE,UNCERTAINTYDEGREE,SHIJISHUCHUZHI;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '410-1994_6_4',//检测项编号
        Remark: '交流电压输出-绝对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'READVALUE|ACTUALVALUE,SHIJISHUCHUZHI,UNCERTAINTYDEGREE,RELATIVEERROR;',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|READVALUE,ACTUALVALUE,SHIJISHUCHUZHI,RELATIVEERROR,UNCERTAINTYDEGREE;HZ|HZMY;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',ACTUALVALUE,',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称)
                //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称;输出示值属性名称或者标准值属性名称;频率属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
                //例如：显示值属性名称;量程属性名称;K属性名称;;;;
                //按钮计算不确定(A:检测项属性名称)
                JiSuanBuQueDingDu: 'Z:UNCERTAINTYDEGREE|SHIJISHUCHUZHI;READVALUE;K;;ACTUALVALUE;HZMY;',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '440-2008_3_1_1',//检测项编号
        Remark: '工频相位测量-绝对误差-一列',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'hidden',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,
    {
        RuleID: '440-2008_3_2_1',//检测项编号
        Remark: '工频相位输出-绝对误差-一列',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'hidden',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,
    {
        RuleID: '440-2008_3_1_2',//检测项编号
        Remark: '工频相位测量-绝对误差-两列',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'hidden',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,
    {
        RuleID: '440-2008_3_2_2',//检测项编号
        Remark: '工频相位输出-绝对误差-两列',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'hidden',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,

    {
        RuleID: '440-2008_3_1_4',//检测项编号
        Remark: '工频相位测量-绝对误差-三列 多通道）',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'show',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,
    {
        RuleID: '440-2008_3_2_4',//检测项编号
        Remark: '工频相位输出-绝对误差-三列 多通道）',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'show',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,
    {
        RuleID: '126-1995_2_2_1',//检测项编号
        Remark: '变送器-电压-引用误差',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'show',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,
    {
        RuleID: '126-1995_2_3_1',//检测项编号
        Remark: '变送器-电流-引用误差',//检测项说明
        Attributes:
        [{
            //添加通道按钮是否显示show:显示，hidden:不显示
            DuoTongDao: 'show',
            //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
            //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
            LianDongDanWeiDDL: '',
            //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
            //DianLiu:电流单位；DianYa:电压单位   
            //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
            DanWeiHtmlDDL: '',
            //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
            BuBaoCunShuJu: '',
            //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
            //OUTPUT_VALUE：输出示值
            CalculateForAddLianCheng: '',
            //不确定度
            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
            //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
            JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
            //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
            JiSuanBuQueDingDu_DiBu: 'N'
        }]
    }
    ,
    {
        RuleID: '126-1995_2_6_1',//检测项编号
        Remark: '变送器-功率-引用误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'LC|OUTPUTVALUE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '126-1995_2_1_1',//检测项编号
        Remark: '变送器-频率-引用误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'HZ|OUTPUTVALUE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '126-1995_2_7_1',//检测项编号
        Remark: '变送器-相位-引用误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '126-1995_2_4_1',//检测项编号
        Remark: '变送器-有功功率-引用误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '126-1995_2_5_1',//检测项编号
        Remark: '变送器-无功功率-引用误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '780-1992_3_2_2',//检测项编号
        Remark: '有功功率输出-三相四线有功功率',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:SHIJISHUCHUZHI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '780-1992_3_1_2',//检测项编号
        Remark: '有功功率测量-三相四线有功功率',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:SHIJISHUCHUZHI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '780-1992_3_2_1',//检测项编号
        Remark: '有功功率输出-三相三线有功功率',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:SHIJISHUCHUZHI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '780-1992_3_1_1',//检测项编号
        Remark: '有功功率测量-三相三线有功功率',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:SHIJISHUCHUZHI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
 
          ///////////////////直流仪器//////////////////////////////////
                   ,
    {
        RuleID: '1052-2009_2_1',//检测项编号
        Remark: '电阻示值误差-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|READVAL1;OM|READVALUE,ACTUALVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '1052-2009_6',//检测项编号
        Remark: '工作电流示值误差-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianLiu|DIANLIUZHIZHI,DIANLIUSHIJIZHI;OM|STANDARDRESISTANCE;DianYa|OUTPUTVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
    ,
    {
        RuleID: '1052-2009_10',//检测项编号
        Remark: '绝缘电阻-无误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
     ,
    {
        RuleID: '166-1993_3_1',//检测项编号
        Remark: '1000Ω以下-无误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
      ,
    {
        RuleID: '166-1993_3_2',//检测项编号
        Remark: '1000Ω以下-标准电阻-相对误差-无型号编号',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
       ,
    {
        RuleID: '166-1993_3_3',//检测项编号
        Remark: '1000Ω以上-无误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
     ,
    {
        RuleID: '166-1993_3_4',//检测项编号
        Remark: '标准电阻箱-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }
     ,
    {
        RuleID: '125-2004_9_1',//检测项编号
        Remark: '标准电阻箱-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }
    ,
    {
        RuleID: '125-2004_9_2',//检测项编号
        Remark: '单桥-其他量程-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }
      ,
    {
        RuleID: '125-2004_9_3',//检测项编号
        Remark: '双桥-基本量程-滑线盘步进盘-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }
      ,
    {
        RuleID: '125-2004_9_4',//检测项编号
        Remark: '双桥-其他量程-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }
     ,
    {
        RuleID: '982-2003_4',//检测项编号
        Remark: '残余电阻-无不确定度',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '982-2003_5',//检测项编号
        Remark: '开关变差-无不确定度',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
    ,
    {
        RuleID: '982-2003_6_1',//检测项编号
        Remark: '示值误差-无电压示值',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }
     ,
    {
        RuleID: '982-2003_6_1',//检测项编号
        Remark: '示值误差-无电压示值',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }

                ,
    {
        RuleID: '1072-2011_6_1',//检测项编号
        Remark: '(直流仪器)基本误差-电阻示值-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: 'D'
            }]
    }
         ,
    {
        RuleID: '1072-2011_6_2',//检测项编号
        Remark: '定值电阻-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'OM|OUTPUTVALUE,READVALUE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '315-1983_2_6',//检测项编号
        Remark: '电压表示值误差-相对误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|OUTPUTVALUE,READVALUE,UNCERTAINTYDEGREE;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)                
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
    ///////////////////电能//////////////////////////////////
     ,
    {
        RuleID: '1085-2013_6_1',//检测项编号
        Remark: '平衡负载时有功电能误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|OUTPUTVALUE;DianLiu|OUTPUTVAL1;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:JISUANWUCHA',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '1085-2013_6_3',//检测项编号
        Remark: '平衡负载时有功电能误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|OUTPUTVALUE;DianLiu|OUTPUTVAL1;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:JISUANWUCHA',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
        ,
    {
        RuleID: '1085-2013_6_2',//检测项编号
        Remark: '不平衡负载时有功电能误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|OUTPUTVALUE;DianLiu|OUTPUTVAL1;',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:YINYONGXIANGDUI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
       ,
    {
        RuleID: '1085-2013_7',//检测项编号
        Remark: '电能标准偏差估计值',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '1085-2013_8',//检测项编号
        Remark: '24h变差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '1085-2013_9',//检测项编号
        Remark: '8h变差改变量',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }

     ///////////////////互感器实验室//////////////////////////////////
         ,
    {
        RuleID: '313-2010_6_1',//检测项编号
        Remark: '变比测试',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '', 
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '313-2010_6_2',//检测项编号
        Remark: '误差测试',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '1075-2001_3_1',//检测项编号
        Remark: '探头',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:YINYONGXIANGDUI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '1075-2001_3_2',//检测项编号
        Remark: '钳形表',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '970-2002_3',//检测项编号
        Remark: '变比示值',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:SHIJISHUCHUZHI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '970-2002_4',//检测项编号
        Remark: '标准偏差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:SHIJISHUCHUZHI',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '970-2002_7',//检测项编号
        Remark: '三相连接组别',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '169-2010_4_2',//检测项编号
        Remark: '工作电流工作电压-电流',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '169-2010_4_3',//检测项编号
        Remark: '工作电流工作电压',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    },
    {
        RuleID: '169-2010_5',//检测项编号
        Remark: '仪器分辨力试验',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '169-2010_6_2',//检测项编号
        Remark: '电压电流互感器测量回路-电流',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'N'
            }]
    }
    ,
    {
        RuleID: '169-2010_6_1',//检测项编号
        Remark: '电压电流互感器测量回路-电压',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'G'
            }]
    },
    {
        RuleID: '169-2010_6_3',//检测项编号
        Remark: '二次负荷导纳阻抗误差-电压',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'G'
            }]
    },
    {
        RuleID: '169-2010_6_4',//检测项编号
        Remark: '二次负荷导纳阻抗误差-电流',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'G'
            }]
    },
    {
        RuleID: '1264-2010_3_1',//检测项编号
        Remark: '电压有功分量无功分量',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'G'
            }]
    },
    {
        RuleID: '1264-2010_3_2',//检测项编号
        Remark: '电流-有功分量无功分量',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: 'G'
            }]
    }

     ///////////////////指示仪表实验室//////////////////////////////////

    ,
    {
        RuleID: '124-2005_2',//检测项编号
        Remark: '基本误差和升降变差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'RANGE|ACTUALVALUE,SHIJISHUCHUZHI,RELATIVEERROR',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DYDL|RANGE,ACTUALVALUE,SHIJISHUCHUZHI,RELATIVEERROR',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:JISUANWUCHA',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
    ,
    {
        RuleID: '440-2008_10',//检测项编号
        Remark: '基本误差和升降变差440',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'ZhiHouChaoQian|READVALUE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:JISUANWUCHA',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
      ,
    {
        RuleID: '440-2008_9',//检测项编号
        Remark: '非额定负载影响',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'ZhiHouChaoQian|READVALUE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
      ,
    {
        RuleID: '603-2006_6',//检测项编号
        Remark: '测量误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:JISUANWUCHA',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
      ,
    {
        RuleID: '124-2005_3',//检测项编号
        Remark: '偏离零位',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
      ,
    {
        RuleID: '622-1997_3',//检测项编号
        Remark: '基本误差检定',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'OUTPUTVALUE|ACTUALVALUE,SHIJISHUCHUZHI',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE;OM|OUTPUTVALUE,ACTUALVALUE,SHIJISHUCHUZHI',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
      ,
    {
        RuleID: '1005-2005_3',//检测项编号
        Remark: '示值误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: 'OUTPUTVALUE|ACTUALVALUE,SHIJISHUCHUZHI',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: 'DianYa|RANGE;OM|OUTPUTVALUE,ACTUALVALUE,SHIJISHUCHUZHI',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '622-1997_4',//检测项编号622-1997_6
        Remark: '钮端电压',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '1005-2005_4',//检测项编号622-1997_6
        Remark: '钮端电压',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:BUQUEDINGDU',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '622-1997_5',//检测项编号622-1997_6
        Remark: '钮端电压稳定性',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
    ,
    {
        RuleID: '622-1997_6',//检测项编号622-1997_6
        Remark: '倾斜影响',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
      ,
    {
        RuleID: '366-2004_4_1',//检测项编号
        Remark: '电子式示值误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
        ,
    {
        RuleID: '366-2004_4_2',//检测项编号
        Remark: '指针式示值误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: 'A:UNCERTAINTYDEGREE',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
        ,
    {
        RuleID: '366-2004_5',//检测项编号
        Remark: '位置影响',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '366-2004_6_1',//检测项编号
        Remark: '电子式辅助电阻影响',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    },
    {
        RuleID: '366-2004_6_2',//检测项编号
        Remark: '指针式示值误差',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示show:显示，hidden:不显示
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动:变更项名称1|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '',
                //检测项属性单位下拉框选项单位类型1|检测项属性单位名称1,检测项属性单位名称2;单位类型2|检测项属性单位名称1,检测项属性单位名称2
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|RANGE_UNIT:量程,OUTPUT_VALUE_UNIT:输出示值,ACTUAL_OUTPUT_VALUE_UNIT：输出实际值;DianYa|READ_VALUE_UNIT:读数值',
                DanWeiHtmlDDL: '',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列,检测项属性单位名称1,检测项属性单位名称2,
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: '',
                //不确定度
                //检测项属性名称后需要加自动或者按钮不确定计算
                //自动计算不确定(Z:检测项属性名称1,检测项属性名称2)
                //按钮计算不确定(A:检测项属性名称1,检测项属性名称2)
                JiSuanBuQueDingDu: '',
                //是否有底部计算不确定度按钮,(D:动态可添加行、G:固定两行,如果没有可不设置)
                JiSuanBuQueDingDu_DiBu: ''
            }]
    }
];
