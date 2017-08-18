<?php

class Dashboard extends My_Controller
{
    function __construct()
    {
        parent::__construct();
        $this->load->model('administrar/dispositivos_m');
    }
    
    function index()
    {
        $data['content_view'] = 'dashboard/dashboard_v';        
        if (isset($this->session->userdata['logged_in'])) {
            if($this->session->userdata['logged_in']['rol']=='Admin')               
                $data['data'] = $this->dispositivos_m->get_dispositivos(null);
            
            else
                $data['data'] = $this->dispositivos_m->get_dispositivos_usuario($this->session->userdata['logged_in']['id']);
        }
        
        $this->template->global_template($data);
        
    }
    
    function publishOnTopic($clientId = null, $topic = null, $command = null)
    {
        if($topic != null){
            if($command != null){
                if($clientId===null) $clientId = time() + rand(0,100);
                $params = array('address'=>'xiot.dynu.com','port'=>1883,'clientid'=>$clientId);
                $this->load->library('phpMQTT',$params);
                if($this->phpMQTT->connect()){
                    $this->phpMQTT->publish($topic,$command,0);
                }
            }
        }
    }
    
}