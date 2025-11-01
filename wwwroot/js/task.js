// JavaScript source code  
'use strict'  
$(document).ready(function ()  
{  
    //getTasks();  
});  
function getApi() {    
    var api = 'http://localhost:5274/api/tasks' ;
    return api;
}
  
function getTasks() {  
    const api = getApi();
    $.getJSON(api).then(function (data) {  
        console.log(data);          
        for (var i = 0, len = data.length; i < len; i++) {  
            $('table>tbody').append(createTag(data[i]));  
            }  
        }).catch(function (err) {  
            console.log(err);  
        });  
}  

function getTask(id) {  
    const api = getApi()+"/"+id;
    $.getJSON(api).then(function (data) {  
        console.log(data);  
        $('table>tbody').append(createTag(data));  
        }).catch(function (err) {  
            console.log(err);  
        });  
}  
function getTaskByPriority(priority) {  
    const api = getApi()+"/priority/"+priority;
    $.getJSON(api).then(function (data) {  
        console.log(data);          
        for (var i = 0, len = data.length; i < len; i++) {  
            $('table>tbody').append(createTag(data[i]));  
            }  
        }).catch(function (err) {  
            console.log(err);  
        });  
}  

function tableRefresh() {
    tableClear();
    getTasks();
}
function tableRefreshTask() {
    tableClear();

    var id = $('#taskid').val();
    getTask(id);
}

function tableRefreshPriority() {
    tableClear();

    var priority = $('#priority').val();
    getTaskByPriority(priority);
}

function tableClear() {
    $('table>tbody').empty();
}



  
function createTask(task) {  
    let tag = `  
        <tr>  
            <td>  
                ${task.id}  
            </td>  
            <td>  
                ${task.title}  
            </td>  
            <td>  
               ${task.description}  
            </td>  
            <td>  
               ${task.isCompleted}  
            </td>  
            <td>  
               ${task.dueDate}  
            </td>  
        </tr>  
    `;  
    
  
    return tag;  
}  
function createTag(task) {  
    let tag = '<tr><td>' + task.id          + '</td>';  
    tag    += '<td>'     + task.title       + '</td>';  
    tag    += '<td>'     + task.description + '</td>';  
    tag    += '<td>'     + task.isCompleted + '</td>';  
    tag    += '<td>'     + task.dueDate     + '</td></tr>';  
    return tag;
}

$('form').submit(function (e) {  
    const api = getApi();

    e.preventDefault();  
    const data = {  
        id:          $('#id').val(),  
        title:       $('#title').val(),  
        description: $('#description').val()  ,
        isCompleted: $('#iscompleted').is(':checked'),
        dueDate:     $('#duedate').val()
    }  

    let tag=createTag(data);
    $('table>tbody').append(tag);    
     
    console.log(data);  
    $.post(api, data ).then(function (response) {
        console.log(response);
    }).catch(function (error) {
        console.log(error);
    }).fail(function() {
        console.log( "error" );
    })    ;  

});  
