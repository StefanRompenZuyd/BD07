<!doctype html>
<html lang="nl">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <meta name="description" content="">
    <meta name="author" content="">

    <title>MyMed</title>

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <link href="https://cdn.datatables.net/1.12.0/css/dataTables.bootstrap5.min.css" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <script src="https://cdn.datatables.net/1.12.0/js/jquery.dataTables.min.js"></script>

    <script src="https://cdn.datatables.net/1.12.0/js/dataTables.bootstrap5.min.js"></script>


    <!-- CSS FILES -->
    <link href="../stylesheet2.css" rel="stylesheet">

    <!-- Test -->
</head>
<body>
  <script src="../test.js"></script>

  
  <!-- ============================ Navbar ============================ -->
  <ul class="navbarul">
    <li><a href="../Index.html">MyMed</a></li>
    <li style="float:right"><a class="active" href="">Mijn Account</a></li>
  </ul>


    
  <!-- ============================ Content ============================ -->
  
  <div class="container">
    <h1 class="mt-4 mb-4 text-center text-primary">Mijn Medicijnen</h1>
    <span id="messquantity"></span>
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col col-sm-9">Medicijnen</div>
                <div class="col col-sm-3">
                    <button type="button" id="add_data" class="btn btn-success btn-sm float-end">Add</button>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-striped table-bordered" id="sample_data">
                    <thead>
                        <tr>
                            <th>Naam</th>
                            <th>Patient</th>
                            <th>Inname</th>
                            <th>Hoeveelheid</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                    
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
</body>
</html>

<div class="modal" tabindex="-1" id="action_modal">
<div class="modal-dialog">
<div class="modal-content">
    <form method="post" id="sample_form">
        <div class="modal-header">
            <h5 class="modal-title" id="dynamic_modal_title">Add Data</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <div class="mb-3">
                <label class="form-label">Naam Medicijn</label>
                <input type="text" name="med_name" id="med_name" class="form-control" />
                <span id="med_name_error" class="text-danger"></span>
            </div>
            <div class="mb-3">
                <label class="form-label">Patient</label>
                <input type="text" name="patient_name" id="patient_name" class="form-control" />
                <span id="patient_name_error" class="text-danger"></span>
            </div>
            <div class="mb-3">
                <label class="form-label">Inname</label>
                <input type="number" name="intake" id="intake" class="form-control" />
                <span id="intake_error" class="text-danger"></span>
            </div>
            <div class="mb-3">
                <label class="form-label">Hoeveelheid</label>
                <input type="number" name="quantity" id="quantity" class="form-control" />
                <span id="quantity_error" class="text-danger"></span>
            </div>
        </div>
        <div class="modal-footer">
            <input type="hidden" name="id" id="id" value="" />
            <input type="hidden" name="action" id="action" value="Add" />
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="submit" class="btn btn-primary" id="action_button">Add</button>
        </div>
    </form>
</div>
</div>
</div>

<script>

$(document).ready(function(){

load_data();

function load_data()
{
var seconds = new Date() / 1000;

$.getJSON("data.json?"+seconds+"", function(data){

    data.sort(function (a, b) {
        return b.id - a.id
    });

    var data_arr = [];

    for(var count = 0; count < data.length; count++)
    {
        var sub_arr = {
            'med_name' : data[count].med_name,
            'patient_name' : data[count].patient_name,
            'intake' : data[count].intake,
            'quantity' : data[count].quantity,
            'action' : '<button type="button" class="btn btn-warning btn-sm edit" data-id="'+data[count].id+'">Edit</button>&nbsp;<button type="button" class="btn btn-danger btn-sm delete" data-id="'+data[count].id+'">Delete</button>'
        };

        data_arr.push(sub_arr);
    }

    console.log(data_arr);

    $('#sample_data').DataTable({
        data:data_arr,
        order:[],
        columns: [
            { data: "med_name" },
            { data: "patient_name" },
            { data: "intake" },
            { data: "quantity" },
            { data: "action" },
        ]
    });

});       

}





$('#add_data').click(function(){

$('#dynamic_modal_title').text('Add Data');

$('#sample_form')[0].reset();

$('#action').val('Add');

$('#action_button').text('Add');

$('.text-danger').text('');

$('#action_modal').modal('show');

});

$('#sample_form').on('submit', function(event){

event.preventDefault();

$.ajax({
    url:"action.php",
    method:"POST",
    data:$('#sample_form').serialize(),
    dataType:"JSON",
    beforeSend:function(){
        $('#action_button').attr('disabled','disabled');
    },
    success:function(data)
    {
        $('#action_button').attr('disabled',false);
        if(data.error)
        {
            if(data.error.med_name_error)
            {
                $('#med_name_error').text(data.error.med_name_error);
            }
            if(data.error.patient_name_error)
            {
                $('#patient_name_error').text(data.error.patient_name_error);
            }

            if(data.error.quantity_error)
            {
                $('#quantity_error').text(data.error.quantity_error);
            }
        }
        else
        {
            $('#messquantity').html('<div class="alert alert-success">'+data.success+'</div>');
            $('#action_modal').modal('hide');

            $('#sample_data').DataTable().destroy();
            
            load_data();

            setTimeout(function(){
                $('#messquantity').html('');
            }, 5000);
        }
    }
});

});

$(document).on('click', '.edit', function(){

var id = $(this).data('id');

$('#dynamic_modal_title').text('Edit Data');

$('#action').val('Edit');

$('#action_button').text('Edit');

$('.text-danger').text('');

$('#action_modal').modal('show');

$.ajax({
    url:"action.php",
    method:"POST",
    data:{id:id, action:'fetch_single'},
    dataType:"JSON",
    success:function(data)
    {
        $('#med_name').val(data.med_name);
        $('#patient_name').val(data.patient_name);
        $('#intake').val(data.intake);
        $('#quantity').val(data.quantity);
        $('#id').val(data.id);
    }
});

});

$(document).on('click', '.delete', function(){

var id = $(this).data('id');

if(confirm("Are you sure you want to delete this data?"))
{
    $.ajax({
        url:"action.php",
        method:"POST",
        data:{action:'delete', id:id},
        dataType:"JSON",
        success:function(data)
        {
            $('#messquantity').html('<div class="alert alert-success">'+data.success+'</div>');

            $('#sample_data').DataTable().destroy();

            load_data();

            setTimeout(function(){
                $('#messquantity').html('');
            }, 5000);
        }
    });
}

});


});

</script>