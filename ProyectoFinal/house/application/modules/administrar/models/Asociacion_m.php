<?php
class Asociacion_m extends CI_Model {

    public function __construct()
    {
        $this->load->database();
    }
    
    public function get_asociacion()
    {
        $this->db->select('usuario_disp.id_registro as registro, usuario.nombre as usuario, dispositivo.nombre as dispositivo');
        $this->db->from('usuario_disp');
        $this->db->join('usuario', 'usuario.id_usuario = usuario_disp.id_usuario');
        $this->db->join('dispositivo', 'dispositivo.id_dispositivo = usuario_disp.id_dispositivo');
        $query = $this->db->get();
        return $query->result_array();
    }
    
     public function nuevaAsociacion()
    {
        $this->load->helper('url');

        $data = array(
            'id_usuario' => $this->input->post('usuario'),
            'id_dispositivo' => $this->input->post('dispositivo')
        );
         
        $query = $this->db->get_where('usuario_disp',$data);
        if($query->row_array()!==null)
            return 2;
        else
            return $this->db->insert('usuario_disp', $data);
    }
    
    public function eliminarAsociacion($id = null)
    {
        $this->db->where('id_registro', $id);
        return $this->db->delete('usuario_disp');
    }
}