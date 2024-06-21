'use client';

import { BuisnessmanType } from '@/app/shared/models/enums/BuisnessmanType';
import React, { useState } from 'react';
import MainEvents from './main-page-events';

export default function Main() {
  const selectType = MainEvents();
  const [selectedType, setSelectedType] = useState<BuisnessmanType>(
    BuisnessmanType.IndividualEntrepreneur
  );

  const handleTypeSelect = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedValue = parseInt(event.target.value) as BuisnessmanType;
    setSelectedType(selectedValue);
    selectType(selectedValue);
  };

  return (
    <div>
      <select
        className="form-select"
        onChange={handleTypeSelect}
        value={selectedType}
        aria-label="Default select example"
      >
        <option value={BuisnessmanType.IndividualEntrepreneur}>
          Индивидуальный предприниматель (ИП)
        </option>
        <option value={BuisnessmanType.LimitedLiabilityCompany}>
          Общество с ограниченной ответственностью (ООО)
        </option>
      </select>
    </div>
  );
}