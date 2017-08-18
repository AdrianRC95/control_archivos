<?php

class Administrar extends My_Controller
{
    function __construct()
    {
        parent::__construct();
    }
    
    function index()
    {
        $data['content_view'] = 'home/home_v';
        $data['data'] = null;
        $this->template->global_template($data);
    }
    
}