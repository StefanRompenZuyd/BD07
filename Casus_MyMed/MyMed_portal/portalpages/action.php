<?php

//action.php

if(isset($_POST['action']))
{
	$file = 'data.json';

	if($_POST['action'] == 'Add' || $_POST['action'] == 'Edit')
	{
		$error = array();

		$data = array();

		$data['id']	= time();

		if(empty($_POST['med_name']))
		{
			$error['med_name_error'] = 'First Name is Required';
		}
		else
		{
			$data['med_name'] = trim($_POST['med_name']);
		}

		if(empty($_POST['patient_name']))
		{
			$error['patient_name_error'] = 'Last Name is Required';
		}
		else
		{
			$data['patient_name'] = trim($_POST['patient_name']);
		}

		$data['intake'] = trim($_POST['intake']);

		if(empty($_POST['quantity']))
		{
			$error['quantity_error'] = 'quantity is required';
		}
		else
		{
			$data['quantity'] = trim($_POST['quantity']);
		}

		if(count($error) > 0)
		{
			$output = array(
				'error'		=>	$error
			);
		}
		else
		{
			if($_POST['action'] == 'Add')
			{
				$file_data = json_decode(file_get_contents($file), true);

				//print_r($file_data);

				$file_data[] = $data;

				file_put_contents($file, json_encode($file_data));
				$output = array(
					'success'	=>	'Data Added'
				);
			}

			if($_POST['action'] == 'Edit')
			{
				$file_data = json_decode(file_get_contents($file), true);

				$key = array_search($_POST['id'], array_column($file_data, 'id'));

				$file_data[$key]['med_name'] = $data['med_name'];
				$file_data[$key]['patient_name'] = $data['patient_name'];
				$file_data[$key]['quantity'] = $data['quantity'];
				$file_data[$key]['intake'] = $data['intake'];

				file_put_contents($file, json_encode($file_data));

				$output = array(
					'success'	=>	'Data Edited'
				);

			}
		}

		echo json_encode($output);
	}

	if($_POST['action'] == 'fetch_single')
	{
		$file_data = json_decode(file_get_contents($file), true);

		$key = array_search($_POST['id'], array_column($file_data, 'id'));

		echo json_encode($file_data[$key]);
	}

	if($_POST['action'] == 'delete')
	{
		$file_data = json_decode(file_get_contents($file), true);

		$key = array_search($_POST['id'], array_column($file_data, 'id'));

		unset($file_data[$key]);

		file_put_contents($file, json_encode($file_data));

		echo json_encode(['success' => 'Data Deleted']);
	}
}

?>
