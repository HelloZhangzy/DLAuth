var From = function () {
    var ajaxTree = function () {
        $("#OrgTree")
        .on('changed.jstree', function (e, data) {             
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
        $("#UserList").bootstrapTable('refresh',{url: "/SystemManage/UserManage/GetOrgUsers?OrgID=" + rowid});
    };


    var TableInit = function () {
        $('#UserList').bootstrapTable({
                url: "/SystemManage/UserManage/GetOrgUsers?OrgID=#",         //请求后台的URL（*）
                method: 'get',                      //请求方式（*）
                //工具按钮用哪个容器 toolbar: '#toolbar',                
                striped: true,                      //是否显示行间隔色
                cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
                pagination: false,                   //是否显示分页（*）
                sortable: false,                     //是否启用排序
                sortOrder: "asc",                   //排序方式               
                sidePagination: "client",           //分页方式：client客户端分页，server服务端分页（*）
                pageNumber: 1,                       //初始化加载第一页，默认第一页
                pageSize: 10,                       //每页的记录行数（*）
                pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
                search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
                strictSearch: false,
                showColumns: false,                  //是否显示所有的列
                showRefresh: false,                  //是否显示刷新按钮
                minimumCountColumns: 2,             //最少允许的列数
                clickToSelect: true,                //是否启用点击选中行              
                uniqueId: "UserCode",                     //每一行的唯一标识，一般为主键列              
                columns: [{ field: 'UserName', title: '姓名', width: 200 },                   
                    { field: 'LoginCode', title: '登录编号', width: 200 },
                    {field: 'Sex', title: '性别', width: 60, formatter: function indexFormatter(value, row, index) {if (value === 0) return '男'; else return '女';}
                    },
                    {field: 'ibState', title: '状态', width: 50, formatter: function indexFormatter(value, row, index) {
                            return value === true ? "<i class=\"fa fa-toggle-on\" style=\"color:#24c734;\"></i>" : "<i class=\"fa fa-toggle-off\"  style=\"color:#ff6161;\"></i>";
                        } },
                    { field: 'LastLoginDate', title: '最后登录时间', width: 200 },
                    { field: 'CreaterDate', title: '创建时间', width: 200 },
                    { field: 'UserExplain', title: '备注', width: 200 },
                    {
                        width: 180,                        
                        title: '操作',
                        align: 'center',
                        events: operateEvents,
                        formatter: operateFormatter
                     },
                ],
        });

        function operateFormatter(value, row, index) {
            var str = row.ibState == true ? "禁用" : "启用";
            return [
                    '<input id="Edit" type="button" class="btn btn-success btn-xs" value="编辑" />',                         
                    '<input id="Reset" type="button" class="btn btn-warning btn-xs" value="重置密码"/>',                            
                    '<input id="Update" type="button" class="btn btn-danger btn-xs Update" value="'+ str +'"/>',
                    '<button class="btn btn-outline red-mint  udp1" >Confirmation on top</button>'
            ].join('');
        };
};
   
    var InitTable = function () {
        $('#UserList').bootstrapTable({
            method: 'get',
            cache: false,
            height: 400,
            striped: true,
            pagination: true,
            pageSize: 20,
            pageNumber: 1,
            pageList: [10, 20, 50, 100, 200, 500],
            sidePagination: 'client',
            search: true,
            showColumns: true,
            showRefresh: false,
            showExport: false,
            exportTypes: ['csv', 'txt', 'xml'],
            search: true,
            clickToSelect: true,
            columns:
            [
                {
                    field: 'UserName', title: '姓名', formatter: function indexFormatter(value, row, index) {
                        if (value === 0) return '男'; else return '女';
                    } 
                },
                { field: 'Sex', title: '性别' },
                { field: 'LoginCode', title: '登录编号' },
                { field: 'LastLoginDate', title: '最后登录时间' },
                { field: 'CreateUserCode', title: '创建时间' },
                { field: 'UserExplain', title: '备注' }

            ],
            url: "/SystemManage/UserManage/GetOrgUsers?OrgID=#",         //请求后台的URL（*）
        });
    };

    return {
        init: function () {
            ajaxTree();
            TableInit();
        }
    };
}();

 window.operateEvents = {
            'click #Edit': function (e, value, row, index) {
                alert("A");
            },
            'click #Reset': function (e, value, row, index) {
                alert("B");
            }
        };

$(document).ready(function () {   
    From.init();

    $('.udp1').on('canceled.bs.confirmation', function () {
            alert('You canceled action #2');
        });
   
});