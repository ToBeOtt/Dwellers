import React from 'react';
import Modal from 'react-bootstrap/Modal';

const DwellerModal = ({ isOpen, onClose, header, body, footer }) => {
  return (
    <Modal show={isOpen} onHide={onClose}>
       {header && (
      <Modal.Header className="grid grid-cols-2 items-center gap-4 m-2">
        {header}
      </Modal.Header>
       )}
      <Modal.Body className="text-contentText font-contentFont m-3">
        {body}
      </Modal.Body>

      {footer && (
      <Modal.Body>
        {footer}
      </Modal.Body>
      )}
    </Modal>
  );
};

export default DwellerModal;
