<?php

namespace OfficeCleaner1;

if (PHP_SAPI === 'cli') { 
  require_once __DIR__ . '/../../vendor/autoload.php';
  Program::main(STDIN);
}
?>
