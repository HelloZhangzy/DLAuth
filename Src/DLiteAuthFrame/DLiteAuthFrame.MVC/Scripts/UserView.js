var From = function () {
    var ajaxTree = function () {
        $("#OrgTree").jstree({
            "core": {              
                'data': {
                    'url': '/SystemManage/OrgManage/GetOrgNode',
                    'dataType': 'json',
                    'data': function (node) {                     
                        return { 'OrgID': node.id };
                    },
                    success: function () {
                        alert('ok');
                    }
                }
            }
        });
    };

    return {
        init: function () {                    
            ajaxTree();
        }
    };
}();

$(document).ready(function () {
    alert('a');
    From.init();
});