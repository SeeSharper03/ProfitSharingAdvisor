$(document).ready(function () {

    $.get('/api/Employees', function (data) {
        drawEmployeeSalaryChart(data);
    });
});


function drawEmployeeSalaryChart(employeeList) {
    var chart = c3.generate({
        bindto: '#chart',
        data: {
            json: employeeList,
            keys: { x: 'employee_Name', value: ['employee_Salary'] },
            names: {
                employee_Salary: 'Salary'
            },
            type: 'bar'
        },
        axis: {
            x: { type: 'category', tick: { rotate: 45, multiline: false} },
            y: { tick: { format: d3.format('$,') } }
        },
        labels: true,
        color: {
            pattern: ['#0099CC']
        },
        bar: {
            width: {
                ratio: 0.5
            }
        }
    });
}