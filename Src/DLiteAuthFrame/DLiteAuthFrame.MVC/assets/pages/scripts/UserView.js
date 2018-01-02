var From = function () {
    var ajaxTree = function () {
        $("#OrgTree")
        .on('changed.jstree', function (e, data) {
             //   alert(data.instance.get_node(data.selected[0]).id);   
                LoadUserList(data.instance.get_node(data.selected[0]).id);        
          })
        .jstree({
            "core": {              
                'data': {
                    'url': '/SystemManage/OrgManage/GetOrgNode',
                    'dataType': 'json',
                    'async' : true,//动态操作 
                    'data': function (node) {                     
                        return { 'OrgID': node.id };
                    }
                }
            }
        });
    };

    var LoadUserList=function(rowid)
    {    
        jQuery("#UserList").jqGrid('setGridParam', { url: "/SystemManage/UserManage/GetOrgUsers?OrgID=" + rowid}).trigger('reloadGrid');
    }

    var UserList=function(id) {
        var $gridList = $("#UserList");
        $gridList.jqGrid({          
            gridview: true,
            url: "/SystemManage/UserManage/GetOrgUsers",
            datatype: "json",
            colModel: [
                { label: "主键", name: "UserCode", index: "", hidden: true, key: true },
                { label: '姓名', name: 'UserName', index: "", width: 200, align: 'left' },
                { label: '性别', name: 'Sex', index: "", width: 100, align: 'left',
                    formatter: function (cellvalue) {
                        return cellvalue == 0 ? "男" : "女";
                    }},
                { label: '登录名', name: 'LoginCode', index: "",  align: 'left' 
                },
                { label: '最后登录时间', name: 'LastLoginDate', index: "", width: 180, align: 'left', formatter: "date",formatoptions: {newformat: 'Y-m-d    H:i:s'}},
                { label: '创建时间', name: 'CreaterDate', index: "", width: 180, align: 'left', formatter: "date", formatoptions: { newformat: 'Y-m-d    H:i:s'}  },
                {
                    label: "状态", name: "ibState", width: 100, align: "center",
                    formatter: function (cellvalue) {
                        return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                    }
                },
                {
                    name: '功能',
                    width: 500,
                    align: 'left',
                    formatter: function (value, grid, rows, state) {
                        var rid = rows.UserCode;
                        var Edit = "UpdateData('" + rid + "')";
                        var reset = "ResetPassWord('" + rid + "')";
                        var str = rows.ibState == true ? "禁用" : "启用";
                        var Update = "UpdateState('" + rid + "','" + str+"')";
                        
                        return '<input id="Edit" type="button" class="btn btn-success btn-xs" name="Submit" value="编辑"  onclick="' + Edit + '"/>'
                            + '&nbsp;&nbsp;'
                            + '<input id="reset" type="button" class="btn btn-warning btn-xs" value="重置密码" onclick="' + reset + '"/>'
                            + '&nbsp;&nbsp;'
                            + '<input id="Update" type="button" class="btn btn-danger btn-xs" value="' + str+'" onclick="' + Update + '"/>'
                            ;
                    }
                }
            ]
        });
    };

    return {
        init: function () {                    
            ajaxTree();
            UserList();
        }
    };
}();

$(document).ready(function () {   
    From.init();
});