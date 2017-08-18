<?php
class Dispositivos_m extends CI_Model {

        public function __construct()
        {
                $this->load->database();
        }
    
    public function agregarDispositivo()
    {
        $this->load->helper('url');

        $data = array(
            'nombre' => $this->input->post('nombre'),
            'localizacion' => $this->input->post('localizacion'),
            'tipo' => $this->input->post('tipo'),
            'estado' => $this->input->post('estado'),
            'valor' => $this->input->post('valor')
        );

        return $this->db->insert('dispositivo', $data);
    }
    
    public function get_dispositivos($id = null)
    {
        if ($id === null)
        {
            $query = $this->db->get('dispositivo');
            return $query->result_array();
        }

        $query = $this->db->get_where('dispositivo', array('id_dispositivo' => $id));
        return $query->result_array();
    }
    
    public function get_dispositivos_usuario($usuario = null)
    {
        if ($usuario === null)
        {
            return null;
        }
        
        $this->db->select('dispositivo.id_dispositivo as id_dispositivo,
                           dispositivo.nombre as nombre, 
                           dispositivo.localizacion as localizacion,
                           dispositivo.tipo as tipo, 
                           dispositivo.estado as estado, 
                           dispositivo.valor as valor');
        $this->db->from('dispositivo');
        $this->db->join('usuario_disp', 'dispositivo.id_dispositivo = usuario_disp.id_dispositivo');
        $this->db->where('usuario_disp.id_usuario', $usuario);
        $query = $this->db->get();
        return $query->result_array();
    }
    
    public function actualizarDispositivo()
    {
        $this->load->helper('url');
        
        $id = $this->input->post('id');
        $data = array(
            'nombre' => $this->input->post('nombre'),
            'localizacion' => $this->input->post('localizacion'),
            'tipo' => $this->input->post('tipo'),
            'estado' => $this->input->post('estado'),
            'valor' => $this->input->post('valor')
        );
        $this->db->where('id_dispositivo', $id);
        return $this->db->update('dispositivo', $data);
    }
    
    public function eliminarDispositivo($id = null)
    {
        $this->db->where('id_dispositivo', $id);
        return $this->db->delete('dispositivo');
    }
}